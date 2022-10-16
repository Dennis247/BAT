namespace BAT.api.Models.Dtos.UserData
{
    public class UserDataDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? MobilephoneType { get; set; }
        public string? State { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Occupation { get; set; }
        public string? PollingUnit { get; set; }
        public string? VotingRAC { get; set; }
        public string? VotingLGA { get; set; }
        public string? StateofOrigin { get; set; }
        public string? StateOfResidence { get; set; }
        public string? Address { get; set; }
        public string? LGA { get; set; }
        public string? TelcoProvider { get; set; }
        public string? MobilePhone { get; set; }
        public string? AirtimeUsage { get; set; }
        public string? WorkStatus { get; set; }
        public string? PVC { get; set; }
        public string? IncomeClass { get; set; }
        public string? AgeCohorts { get; set; }
        public string? FileFields { get; set; }
        public int? FileId { get; set; }
        public string? RAC { get; set; }
    }


    public class UserImportlDataDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? MobilephoneType { get; set; }
        public string? State { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Occupation { get; set; }
        public string? PollingUnit { get; set; }
        public string? VotingRAC { get; set; }
        public string? VotingLGA { get; set; }
        public string? StateofOrigin { get; set; }
        public string? StateOfResidence { get; set; }
        public string? Address { get; set; }
        public string? LGA { get; set; }
        public string? TelcoProvider { get; set; }
        public string? MobilePhone { get; set; }
        public string? AirtimeUsage { get; set; }
        public string? WorkStatus { get; set; }
        public string? PVC { get; set; }
        public string? IncomeClass { get; set; }
        public string? AgeCohorts { get; set; }
        public string? RAC { get; set; }

    }


    public class UserReportDashBoard
    {
        public int ProcessedData { get; set; }
        public int ErrorsGenerated { get; set; }
        public int ReportCreated { get; set; }
        public int UploadedData { get; set; }

        public List<UserReportGraph> UploadedDataGraph { get; set; }
        public List<UserReportGraph> ProcessedDataGraph { get; set; }
    }


    public class UserReportGraph
    {
        public string Hour { get; set; }
        public int Count { get; set; }
    }


    public class UserDashBoardRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


    public class DashBoardRageSearch
    {
        public List<UserReportGraph> UploadedDataGraph { get; set; }
        public List<UserReportGraph> ProcessedDataGraph { get; set; }
    }

}




