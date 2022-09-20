namespace BAT.api.Models.Dtos.AccountDtos;


using System.ComponentModel.DataAnnotations;

public class ValidateResetTokenRequest
{
    [Required]
    public string Token { get; set; }
}