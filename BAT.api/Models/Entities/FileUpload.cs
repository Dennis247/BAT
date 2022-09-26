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
        public FileUploadType FileUploadType { get; set; }

    }

    
}
