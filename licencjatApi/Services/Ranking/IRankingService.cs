using licencjatApi.Models;
using licencjatApi.Models.DTOs;

namespace licencjatApi.Services.Ranking;

public interface IRankingService
{
    RankingDto GetRanking(IEnumerable<CriterionWeight> criterionWeights);
}