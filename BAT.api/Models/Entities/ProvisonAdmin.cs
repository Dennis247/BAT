using System.ComponentModel.DataAnnotations;

namespace BAT.api.Models.Entities
{
    public class ProvisionedAdmin
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime Requested { get; set; }
        public int TeamId { get; set; }

        public int RequesterId { get; set; }
        public bool IsPrivateAdmin { get; set; }
        public bool HasCompletedRegistration { get; set; }
    
    }
}
