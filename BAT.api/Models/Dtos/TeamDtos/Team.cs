using BAT.api.Models.Dtos.AccountDtos;
using BAT.api.Models.Dtos.PermissionDtos;
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
        [Required]
        public int AdminId { get; set; }    
    }


    public class UpdateAdminToTeam
    {
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int AdminId { get; set; }
    }


    public class TeamDetailsId
    {
        [Required]
        public int TeamId { get; set; }
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

    }

    public class TeamWithUsers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AccountForUser> Users { get; set; }
        public List<PermissionDto> Priviledges { get; set; }


    }


    public class TeamWithUserAndPriviledges
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int CretaedBy { get; set; }
        public bool IsDeleted { get; set; }

        public List<AccountResponse> Users { get; set; }

        public List<PermissionDto> Priviledges { get; set; }

    }

    public class UserTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
   

    }

    public class UserTeamWithPriviledges
    {
        public UserTeam UserTeams { get; set; }
        public List<PermissionDto> Priviledges { get; set; }
    }

}
