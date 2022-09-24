namespace BAT.api.Models.Entities
{
    public class TeamPermission
    {
        public int Id { get; set; } 
        public int TeamId { get; set; }
        public int PermissionId { get; set; }
        public DateTime Created { get; set; }
        public  int CreatedBy { get; set; }
    }
}
