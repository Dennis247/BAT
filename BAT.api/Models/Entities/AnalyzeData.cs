namespace BAT.api.Models.Entities
{
    public class AnalyzeData
    {
        public int Id { get; set; } 
        public int FileId { get; set; }
        public  string Objective { get; set; }
        public DateTime DateCreated { get; set; }
        public string ExportStatus { get; set; }    
        public int? AdminId { get; set; }
        public int ExportedBy { get; set; }
        public string AnalyzedRecord { get; set; }
    }


    public class AnalyzeRecordRequest
    {
        public string WidgetType { get; set; }   
        public string Field { get; set; }
        public string Type { get; set; }    

    }
}
