using BAT.api.Models.enums;

namespace BAT.api.Models.Entities
{
    public class FileUpload
    {
        public int Id { get; set; } 
        public string FileName { get; set; }    
        public DateTime DateUploaded { get; set; }
        public string FileType { get; set; }
        public string DownloadUrl { get; set; } 
        public int UploadedBy { get; set; }
        public  string HourUploaded { get; set; }
        public long FileSize { get; set; }
        public FileUploadType FileUploadType { get; set; }


        //merge details
        public bool IsMerged { get; set; }
        public int? MergedBy { get; set; }
        public DateTime? DateMerged { get; set; }
        public string? MergedDetails { get; set; }
        public string? HourMerged { get; set; } 


        // processed details
        public bool IsProcessed { get; set; }
        public int? ProcessedBy { get; set; }
        public DateTime? DateProcessed { get; set; }
        public string? ProcessedIds { get; set; }
        public string? HourProcessed { get; set; }


        //preview Details
        public bool IsInPreviewMode { get; set; }   

        public DateTime? DateSaved { get; set; }
    
    }

    
}
