namespace licencjatApi.Models
{
    public class Criterion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CriterionType Type { get; set; }
        public bool IsStimulant { get; set; }
        public IEnumerable<HostelCriterionValue> HostelCriterionValues { get; set; }
    }
}
