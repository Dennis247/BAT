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

        public long FileSize { get; set; }

        public FileUploadType fileUploadType { get; set; }

        public string TableName
        {
            get
            {
                return getTableName();
            }
        }

        public List<string> Fields
        {
            get
            {
                return getFileFIelds();
            }
        }


        


        public List<string> getFileFIelds()
        {
            if(fileUploadType == FileUploadType.UserData)
            {
                return new List<string> { "firstName", "lastName", "phoneNumber", "state", "gender", "email", "others","fileId" };
            }
            return new List<string> { "" };
        }

        public string getTableName()
        {
            if (fileUploadType == FileUploadType.UserData)
            {
                return "UserDatas";
            }
            return "";
        }

    }

    public class ViewFileId
    {
        public int FileId { get; set; } 
    }


    public class UpdateFile
    {
        public int FileId { get; set; }
        public IFormFile FileContents { get; set; }

    }



}
