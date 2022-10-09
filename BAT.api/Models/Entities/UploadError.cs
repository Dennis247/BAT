using System.ComponentModel.DataAnnotations;

namespace BAT.api.Models.Entities
{
    public class UploadError
    {
        [Key]
        public int Id { get; set; }
        public int UploadedBy { get; set; } 
        public string UploadedByName { get; set; }  
        public DateTime DateUploaded { get; set; }
        public string ErrorDetails { get; set; }    
        public string FileName { get; set; }    

    }
}
