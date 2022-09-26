using BAT.api.Models.enums;
using System.ComponentModel.DataAnnotations;

namespace BAT.api.Models.Entities;

public class Account
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Username { get; set; }
    public string SecretAnswer { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public string VerificationToken { get; set; }
    public DateTime? Verified { get; set; }
    public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
    public string? ResetToken { get; set; }
    public DateTime? ResetTokenExpires { get; set; }
    public DateTime? PasswordReset { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; }

    public bool IsOnline { get; set; }
    public DateTime LastTimeLoggedIn { get; set; }
    public DateTime LoggedOutTime { get; set; }

    public bool OwnsToken(string token)
    {
        return RefreshTokens?.Find(x => x.Token == token) != null;
    }

}