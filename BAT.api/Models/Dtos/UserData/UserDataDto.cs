namespace BAT.api.Models.Dtos.UserData
{
    public class UserDataDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public int FileId { get; set; }
        public bool IsMerged { get; set; }  

    }


    public class UserImportlDataDto
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Location { get; set; }


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


}
