using EnumsNET;

namespace licencjatApi.Models.DTOs
{
    public class CriteriaDto
    {
        public IEnumerable<Criterion> Criteria { get; set; }
        public IEnumerable<string> CriterionTypes { get; }

        public CriteriaDto()
        {
            CriterionTypes = new List<string>()
            {
                CriterionType.DecimalValue.AsString(EnumFormat.Description),
                CriterionType.YesNo.AsString(EnumFormat.Description)
            };
        }
    }
}
