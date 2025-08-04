using licencjatApi.Models;
using licencjatApi.Models.DTOs;

namespace licencjatApi.MulticriteriaSelectionMethods
{
    public class SAWMulticriteriaSelectionMethod : IMulticriteriaSelectionMethod
    {
        public string MethodName => "SAW";

        public RankingDto CalculateRanking(
            IEnumerable<MountainHostel> hostels,
            IEnumerable<Criterion> criteria,
            IEnumerable<HostelCriterionValue> hostelsCriterionValues,
            IEnumerable<CriterionWeight> criterionWeights)
        {
            if (!hostels.Any() || !hostelsCriterionValues.Any() || !criterionWeights.Any())
            {
                return new RankingDto
                {
                    HostelsWithResult = new List<HostelWithResultDto>()
                };
            }

            var hostelsWithResult = hostels
                .Select(h => new HostelWithResultDto() { Hostel = new MountainHostelDto() { Id = h.Id, Name = h.Name }, Result = 0 })
                .ToList();

            foreach (var criterionWeight in criterionWeights)
            {
                if (criterionWeight.Weight == 0)
                    continue;

                var criterionValues = hostelsCriterionValues.Where(v => v.CriterionId == criterionWeight.CriterionId);

                if (!criterionValues.Any())
                    continue;

                var maxValue = criterionValues.Max(h => h.Value);

                if (maxValue == 0)
                    continue;

                var minValue = criterionValues.Min(h => h.Value);

                if (maxValue == minValue)
                    continue;

                var criterionIsStymulant = criteria.Single(c => c.Id == criterionWeight.CriterionId).IsStimulant;

                for (int i = 0; i < hostelsWithResult.Count(); i++)
                {
                    var hostel = hostelsWithResult[i];
                    var criterionValue = criterionValues.SingleOrDefault(hcv => hcv.MountainHostelId == hostel.Hostel.Id);
                    if (criterionValue is null)
                        continue;

                    decimal znormalizowanaWartosc = 0;

                    if (criterionIsStymulant)
                        znormalizowanaWartosc = (criterionValue.Value - minValue) / (maxValue - minValue);
                    else
                        znormalizowanaWartosc = 1 - (criterionValue.Value - minValue) / (maxValue - minValue);

                    hostel.Result += znormalizowanaWartosc * criterionWeight.Weight;
                }
            }

            return new RankingDto()
            {
                HostelsWithResult = hostelsWithResult.OrderByDescending(h => h.Result)
            };
        }
    }
}
