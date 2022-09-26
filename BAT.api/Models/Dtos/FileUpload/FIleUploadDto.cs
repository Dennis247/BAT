using BAT.api.Models.enums;

namespace BAT.api.Models.Dtos.FileUpload
{
 
        public class FileUploadDto
    {
            public int Id { get; set; }
            public string FileName { get; set; }
            public string DateUploaded { get; set; }
            public string FileType { get; set; }
            public int UploadedBy { get; set; }
            public string DownloadUrl { get; set; }

           public FileUploadType fileUploadType { get; set; }

    }

    public class ViewFileId
    {
        public int FileId { get; set; } 
    }
    

 
}
