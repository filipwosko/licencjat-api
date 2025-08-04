using licencjatApi.Models;

namespace licencjatApi.Services.Ranking
{
    public class CriterionWeightNormalizerService
    {
        public static IEnumerable<CriterionWeight> NormalizeWeights(IEnumerable<CriterionWeight> criterionWeights)
        {
            var weightList = criterionWeights.ToList(); 

            var totalWeight = weightList.Sum(cw => cw.Weight);

            if (totalWeight == 0)
            {
                return weightList;
            }

            return weightList
                .Select(cw => new CriterionWeight
                {
                    CriterionId = cw.CriterionId,
                    Weight = cw.Weight / totalWeight
                });
        }
    }
}
