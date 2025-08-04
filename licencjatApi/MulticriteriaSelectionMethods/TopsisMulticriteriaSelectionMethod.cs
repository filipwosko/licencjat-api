using licencjatApi.Models;
using licencjatApi.Models.DTOs;

namespace licencjatApi.MulticriteriaSelectionMethods
{
    public class TopsisMulticriteriaSelectionMethod : IMulticriteriaSelectionMethod
    {
        public string MethodName => "TOPSIS";

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

            var hostelList = hostels.ToList();
            var weights = criterionWeights.ToList();
            var valuesList = hostelsCriterionValues.ToList();

            var criteriaList = criteria
                .Where(c =>
                    weights.Any(w => w.CriterionId == c.Id && w.Weight > 0) &&
                    hostelList.Any(h => valuesList.Any(v => v.MountainHostelId == h.Id && v.CriterionId == c.Id)))
                .ToList();

            if (!criteriaList.Any())
            {
                return new RankingDto
                {
                    HostelsWithResult = hostelList.Select(h => new HostelWithResultDto
                    {
                        Hostel = new MountainHostelDto
                        {
                            Id = h.Id,
                            Name = h.Name
                        },
                        Result = 0
                    }).ToList()
                };
            }

            var valueDict = valuesList
                .GroupBy(v => (v.MountainHostelId, v.CriterionId))
                .ToDictionary(g => g.Key, g => g.First().Value);

            var decisionMatrix = new List<List<decimal?>>();

            foreach (var hostel in hostelList)
            {
                var row = new List<decimal?>();

                foreach (var criterion in criteriaList)
                {
                    decimal? value = valueDict.TryGetValue((hostel.Id, criterion.Id), out var val) ? val : (decimal?)null;
                    row.Add(value);
                }

                decisionMatrix.Add(row);
            }

            for (int j = 0; j < criteriaList.Count; j++)
            {
                double denominator = Math.Sqrt(decisionMatrix
                    .Select(row => row[j])
                    .Where(v => v.HasValue)
                    .Sum(v => Math.Pow((double)v.Value, 2)));

                var weight = weights.FirstOrDefault(w => w.CriterionId == criteriaList[j].Id)?.Weight ?? 0;

                for (int i = 0; i < decisionMatrix.Count; i++)
                {
                    if (decisionMatrix[i][j].HasValue)
                    {
                        decisionMatrix[i][j] = denominator == 0
                            ? 0
                            : (decimal)((double)decisionMatrix[i][j].Value / denominator) * weight;
                    }
                }
            }

            var idealVector = new List<decimal>();
            var antiIdealVector = new List<decimal>();

            for (int j = 0; j < criteriaList.Count; j++)
            {
                var column = decisionMatrix
                    .Select(row => row[j])
                    .Where(v => v.HasValue)
                    .Select(v => v.Value)
                    .ToList();

                var isStimulant = criteriaList[j].IsStimulant;

                idealVector.Add(isStimulant ? column.Max() : column.Min());
                antiIdealVector.Add(isStimulant ? column.Min() : column.Max());
            }

            var distanceFromIdealVector = new List<decimal>();
            var distanceFromAntiIdealVector = new List<decimal>();

            for (int i = 0; i < hostelList.Count; i++)
            {
                decimal distanceToIdeal = 0;
                decimal distanceToAntiIdeal = 0;

                for (int j = 0; j < criteriaList.Count; j++)
                {
                    if (decisionMatrix[i][j].HasValue)
                    {
                        var diffIdeal = decisionMatrix[i][j].Value - idealVector[j];
                        var diffAnti = decisionMatrix[i][j].Value - antiIdealVector[j];

                        distanceToIdeal += diffIdeal * diffIdeal;
                        distanceToAntiIdeal += diffAnti * diffAnti;
                    }
                }

                distanceFromIdealVector.Add((decimal)Math.Sqrt((double)distanceToIdeal));
                distanceFromAntiIdealVector.Add((decimal)Math.Sqrt((double)distanceToAntiIdeal));
            }

            var hostelsWithResult = new List<HostelWithResultDto>();

            for (int i = 0; i < hostelList.Count; i++)
            {
                decimal sum = distanceFromIdealVector[i] + distanceFromAntiIdealVector[i];

                decimal result = sum == 0
                    ? 0
                    : distanceFromAntiIdealVector[i] / sum;

                hostelsWithResult.Add(new HostelWithResultDto
                {
                    Hostel = new MountainHostelDto
                    {
                        Id = hostelList[i].Id,
                        Name = hostelList[i].Name
                    },
                    Result = result
                });
            }

            return new RankingDto
            {
                HostelsWithResult = hostelsWithResult.OrderByDescending(h => h.Result).ToList()
            };
        }
    }
}
