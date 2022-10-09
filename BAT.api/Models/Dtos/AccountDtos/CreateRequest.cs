namespace BAT.api.Models.Dtos.AccountDtos;

using BAT.api.Models.enums;
using System.ComponentModel.DataAnnotations;


public class CreateRequest
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Role { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}


public class ProvisonAdminRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public int TeamId { get; set; }

    public bool IsPrivateAdmin { get; set; }    
    [Required]

    public string RegistrationUrl { get; set; }

    [Required]
    public string SecretAnswer { get; set; }

}




public class RevokeAdminRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }


}

