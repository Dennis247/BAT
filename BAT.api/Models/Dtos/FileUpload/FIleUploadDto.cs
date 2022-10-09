using BAT.api.Models.enums;

namespace BAT.api.Models.Dtos.FileUpload
{
 
        public class FileUploadDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime DateUploaded { get; set; }
        public string FileType { get; set; }
        public string DownloadUrl { get; set; }
        public int UploadedBy { get; set; }
        public string HourUploaded { get; set; }
        public double FileSize { get; set; }

        public string Fields { get; set; }
    }

    public class UserFileUploadDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime DateUploaded { get; set; }
        public string FileType { get; set; }
        public int UploadedBy { get; set; }
        public string HourUploaded { get; set; }
        public double FileSize { get; set; }

        public string Fields { get; set; }
    }

    public class ViewFileId
    {
        public int FileId { get; set; } 
    }

    public class ParameterId
    {
        public int Id { get; set; }
    }


    public class UpdateFile
    {
        public int FileId { get; set; }
        public IFormFile FileContents { get; set; }

    }



}
