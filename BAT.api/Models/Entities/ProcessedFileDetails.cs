namespace BAT.api.Models.Entities
{
    public class ProcessedFileDetails
    {
        public int Id { get; set; } 
        public string FileName { get; set; }    
        public DateTime DateProcessed{ get; set; }
        public  int Administrator { get; set; }
        public string AdministratorName { get; set; }
        public int FileId { get; set; } 
        public string ProcessRule { get; set; }
        public string DownloadUrl { get; set; }

        public string? Fields { get; set; }

        public string? Title { get; set; }
        public int ProcessedItemCount { get; set; }

       public int UploadedFileCount { get; set; }

        public string? HourProcessed { get; set; }

    }


 
}
