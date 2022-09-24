namespace BAT.api.Models.Entities
{
    public class AdminTeam
    {
        public int Id { get; set; } 
        public int TeamId { get; set; } 
        public int AdminId { get; set; }
        public  int AddedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
