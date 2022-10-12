namespace BAT.api.Models.Dtos.TeamDtos
{
    public class TeamPermissionDto
    {
        public int TeamId { get; set; }
        public List<int> Permissions { get; set; }

    }


    public class UpdateTeamPermission
    {
        public string Name { get; set; }
        public int TeamId { get; set; }
        public List<int> PriviledgesId { get; set; }

        public List<int> AdminIds { get; set; }

    }


}
