namespace licencjatApi.Models.DTOs
{
    public class CriterionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CriterionType Type { get; set; }
        public bool IsStimulant { get; set; }
    }   
}
