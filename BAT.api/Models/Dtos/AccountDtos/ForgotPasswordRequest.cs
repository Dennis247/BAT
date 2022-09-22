namespace BAT.api.Models.Dtos.AccountDtos;


using System.ComponentModel.DataAnnotations;

public class ForgotPasswordRequest
{
/*    [Required]
    [EmailAddress]
    public string Email { get; set; }*/


    [Required]
    public string SecretAnswer { get; set; }
}



