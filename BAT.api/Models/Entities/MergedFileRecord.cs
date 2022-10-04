namespace BAT.api.Models.Entities
{
    public class MergedFileRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public string MergeDetails { get; set; }
        public string FileDetails { get; set; }
    }
}
