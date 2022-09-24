using System.ComponentModel.DataAnnotations;

namespace BAT.api.Models.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }     
        public string Name { get; set; }
        public DateTime Created { get; set; }   
        public int CreatedBy { get; set; }

    }
}
