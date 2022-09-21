namespace BAT.api.Services;

using AutoMapper;
using BAT.api.Authorization;
using BAT.api.Data;
using BAT.api.Helpers;
using BAT.api.Models.Dtos.AccountDtos;
using BAT.api.Models.Entities;
using BAT.api.Models.enums;
using BAT.api.Models.Response;
using BCrypt.Net;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public interface IAccountService
{
    Response<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress);
    Response<string> ForgotPassword(ForgotPasswordRequest model, string origin);
    Response<IEnumerable<AccountResponse>> GetAll();
    Response<AccountResponse> GetById(int id);
    Response<AuthenticateResponse> RefreshToken(string token, string ipAddress);
    Response<int> Register(RegisterRequest model, string origin);
    Response<string> ResetPassword(ResetPasswordRequest model);
    Response<bool> RevokeToken(string token, string ipAddress);
    Response<string> VerifyEmail(string token);
}

public class AccountService : IAccountService
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;
    private readonly IEmailService _emailService;

    public AccountService(
        ApplicationDbContext context,
        IJwtUtils jwtUtils,
        IMapper mapper,
        IOptions<AppSettings> appSettings,
        IEmailService emailService)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
        _appSettings = appSettings.Value;
        _emailService = emailService;
    }

    public Response<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress)
    {
        var account = _context.Accounts.SingleOrDefault(x => x.FirstName.ToLower() == model.FirstName.ToLower()
        && x.LastName.ToLower() == model.LastName.ToLower());

        // validate
        if (account == null || !BCrypt.Verify(model.Password, account.PasswordHash) || !BCrypt.Verify(model.SecretAnswer, account.SecretAnswer))
            throw new AppException("Email or password is incorrect");

        // authentication successful so generate jwt and refresh tokens
        var jwtToken = _jwtUtils.GenerateJwtToken(account);
        var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
        account.RefreshTokens.Add(refreshToken);

        // remove old refresh tokens from account
        removeOldRefreshTokens(account);

        // save changes to db
        _context.Update(account);
        _context.SaveChanges();

        var response = _mapper.Map<AuthenticateResponse>(account);
        response.JwtToken = jwtToken;
        response.RefreshToken = refreshToken.Token;
        return new Response<AuthenticateResponse>
        {
            Data = response,
            Message = "Login Sucessful",
            Succeeded = true
        };
    }

    public Response<AuthenticateResponse> RefreshToken(string token, string ipAddress)
    {
        var account = getAccountByRefreshToken(token);
        var refreshToken = account.RefreshTokens.Single(x => x.Token == token);

        if (refreshToken.IsRevoked)
        {
            // revoke all descendant tokens in case this token has been compromised
            revokeDescendantRefreshTokens(refreshToken, account, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
            _context.Update(account);
            _context.SaveChanges();
        }

        if (!refreshToken.IsActive)
            throw new AppException("Invalid token");

        // replace old refresh token with a new one (rotate token)
        var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress);
        account.RefreshTokens.Add(newRefreshToken);

        // remove old refresh tokens from account
        removeOldRefreshTokens(account);

        // save changes to db
        _context.Update(account);
        _context.SaveChanges();

        // generate new jwt
        var jwtToken = _jwtUtils.GenerateJwtToken(account);

        // return data in authenticate response object
        var response = _mapper.Map<AuthenticateResponse>(account);
        response.JwtToken = jwtToken;
        response.RefreshToken = newRefreshToken.Token;
        return new Response<AuthenticateResponse>
        {
            Succeeded = true,
            Message = "Sucessful",
            Data = response,
        };
    }

    public Response<bool> RevokeToken(string token, string ipAddress)
    {
        var account = getAccountByRefreshToken(token);
        var refreshToken = account.RefreshTokens.Single(x => x.Token == token);

        if (!refreshToken.IsActive)
            throw new AppException("Invalid token");

        // revoke token and save
        revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
        _context.Update(account);
        _context.SaveChanges();

        return new Response<bool> { Succeeded = true, Message = "Revoke Token SUcessful", Data = true };
    }

    public Response<int> Register(RegisterRequest model, string origin)
    {
        // check if user already exist using first name , last name and password

        var secretHash = BCrypt.HashPassword(model.SecretAnswer);

        if (_context.Accounts.Any(x =>
        x.FirstName.ToLower() == model.FirstName.ToLower()
         && x.LastName.ToLower() == model.LastName.ToLower() && (x.SecretAnswer == secretHash)
   ))
        {
            throw new AppException("Your information matches an existing user,\nplease fill in the correct information or sign in");
        }



        // map model to new account object
        var account = _mapper.Map<Account>(model);

        // first registered account is an admin
        var isFirstAccount = _context.Accounts.Count() == 0;
        account.Role = isFirstAccount ? Role.Admin : Role.User;
        account.Created = DateTime.UtcNow;
        account.VerificationToken = generateVerificationToken();

        // hash password & sceurity answer
        account.PasswordHash = BCrypt.HashPassword(model.Password);
        account.SecretAnswer = BCrypt.HashPassword(model.SecretAnswer);

        // save account
        _context.Accounts.Add(account);
        _context.SaveChanges();

        // send email
        sendVerificationEmail(account, origin);

        return new Response<int>
        {
            Data = account.Id,
            Succeeded = true,
            Message = "User Registration sucessful"
        };
    }

    public Response<string> VerifyEmail(string token)
    {
        var account = _context.Accounts.SingleOrDefault(x => x.VerificationToken == token);

        if (account == null)
            throw new AppException("Verification failed");

        account.Verified = DateTime.UtcNow;
        account.VerificationToken = null;

        _context.Accounts.Update(account);
        _context.SaveChanges();

        return new Response<string>
        {
            Data = null,
            Message = "Verification Sucessful",
            Succeeded = true
        };


    }

    public Response<string> ForgotPassword(ForgotPasswordRequest model, string origin)
    {
        var secretAnswerHash = BCrypt.HashPassword(model.SecretAnswer);
        var account = _context.Accounts.SingleOrDefault(x => BCrypt.HashPassword(x.SecretAnswer) == BCrypt.HashPassword(secretAnswerHash));

        // always return ok response to prevent email enumeration
        if (account == null)
            return new Response<string>
            {
                Succeeded = false,
                Message = "Account not valid",
                Data = null
            };

        // create reset token that expires after 1 day
        account.ResetToken = generateResetToken();
        account.ResetTokenExpires = DateTime.UtcNow.AddMinutes(10);

        _context.Accounts.Update(account);
        _context.SaveChanges();

        // send email
        sendPasswordResetEmail(account, origin);

        return new Response<string>
        {
            Data = null,
            Message = "Reset Password Email Sent Sucessfully.",
            Succeeded = true
        };
    }

    public Response<string> ResetPassword(ResetPasswordRequest model)
    {
        var account = getAccountByResetToken(model.Token);

        // update password and remove reset token
        account.PasswordHash = BCrypt.HashPassword(model.Password);
        account.PasswordReset = DateTime.UtcNow;
        account.ResetToken = null;
        account.ResetTokenExpires = null;

        _context.Accounts.Update(account);
        _context.SaveChanges();

        return new Response<string>
        {
            Data = null,
            Message = "Reste Password Sucessful,\nYou can now login",
            Succeeded = true
        };
    }

    public Response<IEnumerable<AccountResponse>> GetAll()
    {
        var accounts = _context.Accounts;
        var users = _mapper.Map<IList<AccountResponse>>(accounts);
        return new Response<IEnumerable<AccountResponse>>
        {
            Succeeded = true,
            Message = "Sucessful",
            Data = users
        };
    }

    public Response<AccountResponse> GetById(int id)
    {
        var account = getAccount(id);
        var user = _mapper.Map<AccountResponse>(account);
        return new Response<AccountResponse>
        {
            Succeeded = true,
            Message = "Sucessful",
            Data = user
        };
    }




    // helper methods

 

    private Account getAccount(int id)
    {
        var account = _context.Accounts.Find(id);
        if (account == null) throw new KeyNotFoundException("Account not found");
        return account;
    }

    private Account getAccountByRefreshToken(string token)
    {
        var account = _context.Accounts.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
        if (account == null) throw new AppException("Invalid token");
        return account;
    }

    private Account getAccountByResetToken(string token)
    {
        var account = _context.Accounts.SingleOrDefault(x =>
            x.ResetToken == token && x.ResetTokenExpires > DateTime.UtcNow);
        if (account == null) throw new AppException("Invalid token");
        return account;
    }

    private string generateJwtToken(Account account)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private string generateResetToken()
    {
        // token is a cryptographically strong random sequence of values
        var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        // ensure token is unique by checking against db
        var tokenIsUnique = !_context.Accounts.Any(x => x.ResetToken == token);
        if (!tokenIsUnique)
            return generateResetToken();

        return token;
    }

    private string generateVerificationToken()
    {
        // token is a cryptographically strong random sequence of values
       // var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        var token = new Random().Next(0,999999).ToString();

        // ensure token is unique by checking against db
        var tokenIsUnique = !_context.Accounts.Any(x => x.VerificationToken == token);
        if (!tokenIsUnique)
            return generateVerificationToken();

        return token;
    }

    private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
    {
        var newRefreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
        revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }

    private void removeOldRefreshTokens(Account account)
    {
        account.RefreshTokens.RemoveAll(x =>
            !x.IsActive &&
            x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
    }

    private void revokeDescendantRefreshTokens(RefreshToken refreshToken, Account account, string ipAddress, string reason)
    {
        // recursively traverse the refresh token chain and ensure all descendants are revoked
        if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
        {
            var childToken = account.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
            if (childToken.IsActive)
                revokeRefreshToken(childToken, ipAddress, reason);
            else
                revokeDescendantRefreshTokens(childToken, account, ipAddress, reason);
        }
    }

    private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp = ipAddress;
        token.ReasonRevoked = reason;
        token.ReplacedByToken = replacedByToken;
    }

    private void sendVerificationEmail(Account account, string origin)
    {
        string message;
        if (!string.IsNullOrEmpty(origin))
        {
            // origin exists if request sent from browser single page app (e.g. Angular or React)
            // so send link to verify via single page app
            var verifyUrl = $"{origin}/account/verify-email?token={account.VerificationToken}";
            message = $@"<p>Please click the below link to verify your email address:</p>
                            <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
        }
        else
        {
            // origin missing if request sent directly to api (e.g. from Postman)
            // so send instructions to verify directly with api
            message = $@"<p>Please use the below token to verify your email address with the <code>/accounts/verify-email</code> api route:</p>
                            <p><code>{account.VerificationToken}</code></p>";
        }

        _emailService.Send(
            to: account.Email,
            subject: "Sign-up Verification API - Verify Email",
            html: $@"<h4>Verify Email</h4>
                        <p>Thanks for registering!</p>
                        {message}"
        );
    }



    private void sendPasswordResetEmail(Account account, string origin)
    {
        string message;
        if (!string.IsNullOrEmpty(origin))
        {
            var resetUrl = $"{origin}/account/reset-password?token={account.ResetToken}";
            message = $@"<p>Please click the below link to reset your password, the link will be valid for 1 day:</p>
                            <p><a href=""{resetUrl}"">{resetUrl}</a></p>";
        }
        else
        {
            message = $@"<p>Please use the below token to reset your password with the <code>/accounts/reset-password</code> api route:</p>
                            <p><code>{account.ResetToken}</code></p>";
        }

        _emailService.Send(
            to: account.Email,
            subject: "Sign-up Verification API - Reset Password",
            html: $@"<h4>Reset Password Email</h4>
                        {message}"
        );
    }
}