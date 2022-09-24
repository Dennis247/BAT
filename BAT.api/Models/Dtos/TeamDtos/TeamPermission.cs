namespace BAT.api.Models.Dtos.TeamDtos
{
    public class TeamPermissionDto
    {
        public int TeamId { get; set; }
        public List<int> Permissions { get; set; }

    }


    public class UpdateTeamPermission
    {
        public int TeamId { get; set; }
        public List<int> Permissions { get; set; }

    }


}
