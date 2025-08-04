using licencjatApi.Models;
using licencjatApi.Models.DTOs;

namespace licencjatApi.MulticriteriaSelectionMethods
{
    public interface IMulticriteriaSelectionMethod
    {
        public RankingDto CalculateRanking(
            IEnumerable<MountainHostel> hostels,
            IEnumerable<Criterion> criteria,
            IEnumerable<HostelCriterionValue> hostelsCriterionValues,
            IEnumerable<CriterionWeight> criterionWeights);
        string MethodName { get; }
    }
}
