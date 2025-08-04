using licencjatApi.MulticriteriaSelectionMethods;
using licencjatApi.Models;
using licencjatApi.Models.DTOs;
using licencjatApi.Repositories;
using licencjatApi.Repository;

namespace licencjatApi.Services.Ranking;

public class RankingService : IRankingService
{
    private readonly IProgramParametersRepository _programParameters;
    private readonly IHostelCriterionValueRepository _hostelCriterionValueRepository;
    private readonly IMountainHostelRepository _mountainHostelRepository;
    private readonly ICriterionRepository _criterionRepository;
    private readonly IEnumerable<IMulticriteriaSelectionMethod> _allMulticriteriaSelectionMethods;

    public RankingService(
        IHostelCriterionValueRepository hostelCriterionValueRepository,
        IMountainHostelRepository mountainHostelRepository,
        ICriterionRepository criterionRepository,
        IEnumerable<IMulticriteriaSelectionMethod> allMulticriteriaSelectionMethods,
        IProgramParametersRepository programParameters)
    {
        _hostelCriterionValueRepository = hostelCriterionValueRepository;
        _mountainHostelRepository = mountainHostelRepository;
        _criterionRepository = criterionRepository;
        _allMulticriteriaSelectionMethods = allMulticriteriaSelectionMethods;
        _programParameters = programParameters;
    }

    public RankingDto GetRanking(IEnumerable<CriterionWeight> criterionWeights)
    {
        criterionWeights = CriterionWeightNormalizerService.NormalizeWeights(criterionWeights);

        string methodToRun = _programParameters.MethodName;

        var multicriteriaSelectionMethod = _allMulticriteriaSelectionMethods.FirstOrDefault(x => x.MethodName == methodToRun);
        if (multicriteriaSelectionMethod is null)
            throw new ArgumentException("Niepoprawnie skonfigurowana metoda w parametrach programu.");

        var hostels = _mountainHostelRepository.GetMountainHostels();
        var criteria = _criterionRepository.GetCriteria();

        var hostelCriterionValues = new List<HostelCriterionValue>();
        foreach (var hostel in hostels)
        {
            var values = _hostelCriterionValueRepository.GetByHostelId(hostel.Id);
            hostelCriterionValues.AddRange(values);
        }

        return multicriteriaSelectionMethod.CalculateRanking(hostels, criteria, hostelCriterionValues, criterionWeights);
    }
}