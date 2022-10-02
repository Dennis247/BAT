namespace BAT.api.Models.Entities
{
    public class UserData
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? State { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Others { get; set; }
        public int? FileId { get; set; }
        public DateTime? Created { get; set; }
        public int? CreatedBy { get; set; }

    }
}
