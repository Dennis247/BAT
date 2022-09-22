using System.ComponentModel.DataAnnotations;

namespace BAT.api.Models.Dtos.AccountDtos
{
    public class ResetSecretAnswer
    {
        [Required]
        public string OldSecretAnswer { get; set; }
        [Required]
        public string NewSecretAnswer { get; set; }
        [Required]
        public int UserId { get; set; }  
    }
}
