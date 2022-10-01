namespace BAT.api.Controllers;

using BAT.api.Authorization;
using BAT.api.Models.Dtos.AccountDtos;
using BAT.api.Models.enums;
using BAT.api.Models.Response;
using BAT.api.Services;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountsController : BaseController
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [AllowAnonymous]
    [HttpPost("PrivateAuthenticate")]
    public IActionResult PrivateAuthenticate(AuthenticateRequest model)
    {
        var response = _accountService.Authenticate(model, ipAddress());
        setTokenCookie(response.Data.RefreshToken);
        return Ok(response);
    }


    //[AllowAnonymous]
    //[HttpPost("AuthenticatePrivateAdmin")]
    //public IActionResult AuthenticatePrivateAdmin(AuthenticateRequest model)
    //{
    //    var response = _accountService.AuthenticatePrivateAdmin(model, ipAddress());
    //    setTokenCookie(response.Data.RefreshToken);
    //    return Ok(response);
    //}



    [AllowAnonymous]
    [HttpPost("PublicAuthenticate")]
    public IActionResult PublicAuthenticate(PublicAuthRequest model)
    {
        var response = _accountService.PublicAuthenticate(model, ipAddress());
        setTokenCookie(response.Data.RefreshToken);
        return Ok(response);
    }



    [AllowAnonymous]
    [HttpPost("LogOut")]
    public IActionResult LogOut()
    {
        var response = _accountService.LogOut(Account.Id);
        return Ok(response);
    }



    [AllowAnonymous]
    [HttpPost("RegisterPublicAdmin")]
    public IActionResult RegisterPublicAdmin(RegisterRequest model)
    {
        var response = _accountService.Register(model, Request.Headers["origin"]);
        return Ok(response);
    }


    [AllowAnonymous]
    [HttpPost("RegisterPrivateAdmin")]
    public IActionResult RegisterPrivateAdmin(RegisterRequest model)
    {
        var response = _accountService.RegisterPrivateAdmin(model, Request.Headers["origin"]);
        return Ok(response);
    }




    [AllowAnonymous]
    [HttpPost("ForgotPassword")]
    public IActionResult ForgotPassword(ForgotPasswordRequest model)
    {
        var response = _accountService.ForgotPassword(model, Request.Headers["origin"]);
        return Ok(response);
    }




    [AllowAnonymous]
    [HttpPost("ResetPassword")]
    public IActionResult ResetPassword(ResetPasswordRequest model)
    {
        var response = _accountService.ResetPassword(model);
        return Ok(response);
    }


    [AllowAnonymous]
    [HttpPost("ResetSecretAnswer")]
    public IActionResult ResetSecretAnswer(ResetSecretAnswer model)
    {
       var response = _accountService.ResetSecretAnswer(model);
       return Ok(response);
    }



    [HttpPost("ProvisionAdmin")]
    public IActionResult ProvisionAdmin(ProvisonAdminRequest model)
    {
        var response = _accountService.ProvisionAdmin(model,Account.Id);
        return Ok(response);
    }


    [HttpPost("RevokeAdminInvite")]
    public IActionResult RevokeAdminInvite(RevokeAdminRequest model)
    {
        var response = _accountService.RevokeInvite(model);
        return Ok(response);
    }



    //[HttpPost("DeleteAdmin")]
    //public IActionResult DeleteAdmin(DeleteAdminRequest model)
    //{
    //    var response = _accountService.DeleteAdmin(model);
    //    return Ok(response);
    //}



    [HttpPost("GetPendingAdminActivation")]
    public IActionResult GetPendingAdminActivation()
    {
        var response = _accountService.PendingActivationRequest();
        return Ok(response);
    }



    [HttpPost("DeleteAdmin")]
    public IActionResult DeleteAdmin(DeleteAdminRequest model)
    {
        var response = _accountService.DeleteAdmin(model);
        return Ok(response);
    }



    [AllowAnonymous]
    [HttpPost("RefreshToken")]
    public IActionResult RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var response = _accountService.RefreshToken(refreshToken, ipAddress());
        setTokenCookie(response.Data.RefreshToken);
        return Ok(response);
    }

    [HttpPost("RevokeToken")]
    public IActionResult RevokeToken(RevokeTokenRequest model)
    {
        // accept token from request body or cookie
        var token = model.Token ?? Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(token))
            return BadRequest(new { message = "Token is required" });

        // users can revoke their own tokens and admins can revoke any tokens
        if (!Account.OwnsToken(token) && Account.Role != ROLES.Admin)
            return Unauthorized(new { message = "Unauthorized" });

        _accountService.RevokeToken(token, ipAddress());
        return Ok(new { message = "Token revoked" });
    }


    [AllowAnonymous]
    [HttpPost("VerifyEmail")]
    public IActionResult VerifyEmail(VerifyEmailRequest model)
    {
        var response =   _accountService.VerifyEmail(model.Token);
        return Ok(response);
    }

 


 
  //  [Authorize(ROLES.Admin)]
    [HttpGet]
    public ActionResult<IEnumerable<AccountResponse>> GetAll()
    {
        var response = _accountService.GetAll();
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("GetAccountById")]
    public IActionResult GetAccountById(int id)
    {
        // users can get their own account and admins can get any account

        var response = _accountService.GetById(id);
        return Ok(response);
    }

    //[Authorize(Role.Admin)]
    //[HttpPost]
    //public ActionResult<AccountResponse> Create(CreateRequest model)
    //{
    //    var account = _accountService.Create(model);
    //    return Ok(account);
    //}

    //[HttpPut("{id:int}")]
    //public IActionResult Update(int id, UpdateRequest model)
    //{
    //    // users can update their own account and admins can update any account
    //    if (id != Account.Id && Account.Role != Role.Admin)
    //        return Unauthorized(new { message = "Unauthorized" });

    //    // only admins can update role
    //    if (Account.Role != Role.Admin)
    //        model.Role = null;

    //    var account = _accountService.Update(id, model);
    //    return Ok(account);
    //}



    private void setTokenCookie(string token)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };
        Response.Cookies.Append("refreshToken", token, cookieOptions);
    }

    private string ipAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        else
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
}