using BAT.api.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace BAT.api.Models.Dtos.TeamDtos
{
    public class AddTeam
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public List<int> PriviledgesId { get; set; }

        [Required]
        public List<int> AdminIds { get; set;}
    }

    public class AddAdminToTeam
    {
        [Required]
        public int TeamId { get; set; }
        public int AdminId { get; set; }    
    }


    public class UpdateTeam
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int TeamId { get; set; } 
    }


    public class UpdateTeamStatus
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsActivated { get; set; }
    }


    public class TeamDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int CretaedBy { get; set; }
        public bool IsDeleted { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}
