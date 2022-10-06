namespace BAT.api.Models.Entities
{
    public class ProcessedFileDetails
    {
        public int Id { get; set; } 
        public DateTime DateProcessed{ get; set; }
        public int ProcessedBy { get;set; }
        public int FileId { get; set; } 

        public string ProcessedDetails { get; set; }

    }


    public class ProcessedDetails
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string TotalValue { get; set; }
    }
}
