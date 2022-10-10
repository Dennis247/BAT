namespace BAT.api.Models.Entities
{
    public class UserData
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string ? MobileNumer { get; set; }
        public string? State { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Occupation { get; set; }
        public string? PollingUnit { get; set; } 
        public string? VotingRAC { get; set; }
        public string? VotingLGA{ get; set; }
        public string? StateOfResidence { get; set; }
        public string? LGA { get; set; }
        public string? TelcoProvider { get; set; }
        public string? MobilePhone { get; set; }
        public string? AirtimeUsage { get; set; }
        public string? WorkStatus { get; set; }
        public string? PVC { get;set; }
        public string? IncomeClass  { get; set; }
        public string? AgeCohorts  { get; set; }
        public string? FileFields { get; set; }
        public int? FileId { get; set; }
        public DateTime? Created { get; set; }
        public int? CreatedBy { get; set; }

    }
}
