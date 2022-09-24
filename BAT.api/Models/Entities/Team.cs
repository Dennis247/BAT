using System.ComponentModel.DataAnnotations;

namespace BAT.api.Models.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }   
        public DateTime LastTimeUpdated { get; set; }
        public int CretaedBy { get; set; }  
        public int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; } 

    }
}
