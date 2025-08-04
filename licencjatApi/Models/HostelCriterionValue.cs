namespace licencjatApi.Models
{
    public class HostelCriterionValue
    {
        public int Id { get; set; }
        public int MountainHostelId { get; set; }
        public MountainHostel MountainHostel { get; set; }
        public int CriterionId { get; set; }
        public Criterion Criterion { get; set; }
        public decimal Value { get; set; }
    }
}
