namespace BAT.api.Models.Dtos.AccountDtos;


using System.ComponentModel.DataAnnotations;

public class VerifyEmailRequest
{
    [Required]
    public string Token { get; set; }
}