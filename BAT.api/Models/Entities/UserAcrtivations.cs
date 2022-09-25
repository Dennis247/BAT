namespace BAT.api.Models.Entities
{
    public class UserActivation
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateActivated { get; set; }
    }
}
