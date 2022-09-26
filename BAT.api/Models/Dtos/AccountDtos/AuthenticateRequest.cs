namespace BAT.api.Models.Dtos.AccountDtos;

using System.ComponentModel.DataAnnotations;

public class AuthenticateRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string SecretAnswer { get; set; }

    [Required]
    public string Password { get; set; }
}



public class PublicAuthRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string SecretAnswer { get; set; }

    [Required]
    public string Password { get; set; }
}

