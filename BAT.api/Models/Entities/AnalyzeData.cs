namespace BAT.api.Models.Entities
{
    public class AnalyzeData
    {
        public int Id { get; set; } 
        public int FIleId { get; set; } 
        public  string Objective { get; set; }
        public DateTime DateCreated { get; set; }
        public int? AdminId { get; set; }
        public string AdminName { get; set; }
        public string? AnalyzedRecord { get; set; }

        public bool IsApprovedByAdmin { get; set; }
        public int ApprovedBy { get; set; } 
        public string? ApprovedByName { get; set; }  

    //    public string ProcessDownloadUrl { get; set; }
    }

    public class AnalyzeDataDto
    {
        public int Id { get; set; }
        public int FIleId { get; set; }
        public string Objective { get; set; }
        public DateTime DateCreated { get; set; }
        public int? AdminId { get; set; }
        public string AdminName { get; set; }
      //  public string? AnalyzedRecord { get; set; }

        public bool IsApprovedByAdmin { get; set; }
        public int ApprovedBy { get; set; }
        public string? ApprovedByName { get; set; }

        //    public string ProcessDownloadUrl { get; set; }
    }



    public class AnalyzeRecordRequest
    {
        public string WidgetType { get; set; }   
        public string Field { get; set; }
        public string Type { get; set; }    

    }

    public class ExportRequest
    {
        public int Id { get; set; }   
        public int RequestedBy { get; set; }   
        public string Objective { get; set; }
        public string RequestedByName { get; set; } 
        public int? ApprovedBy { get; set; }
        public string? ApprovedByName { get; set; }
        public int AnalyzeRequestId { get; set; }
        public DateTime? DateRequested { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateRejected { get; set; }
        public int? RejectedBy { get; set; }
        public string? RejectedByName { get; set; } 
        public string ExportStatus { get; set; }
       
    }


    //public enum RequestStatus
    //{
    //    None
    //    Pending,
    //    Approved,
    //    Rejected
    //}
}
