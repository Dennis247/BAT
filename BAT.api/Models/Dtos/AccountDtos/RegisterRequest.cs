namespace BAT.api.Models.Dtos.AccountDtos;


using System.ComponentModel.DataAnnotations;

public class RegisterRequest
{


    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string SecretAnswer { get; set; }

    [Required]
    public string Password { get; set; }


    [Required]
    [EmailAddress]
    public string Email { get; set; }


}


