
namespace licencjatApi.Models
{
    public class MountainHostel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<HostelCriterionValue> HostelCriterionValues { get; set; }
    }
}

