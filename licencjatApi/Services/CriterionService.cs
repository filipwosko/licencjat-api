using licencjatApi.Models;
using licencjatApi.Repository;
using licencjatApi.Services.Validators;

namespace licencjatApi.Services;

public class CriterionService : ICriterionService
{
    private readonly ICriterionRepository _criterionRepository;
    private readonly IHostelCriterionValueRepository _hostelCriterionValueRepository;
    private readonly ICriterionValidator _criterionValidator;

    public CriterionService(
        ICriterionRepository CriterionRepository,
        IHostelCriterionValueRepository hostelCriterionValueRepository,
        ICriterionValidator criterionValidator)
    {
        _criterionRepository = CriterionRepository;
        _hostelCriterionValueRepository = hostelCriterionValueRepository;
        _criterionValidator = criterionValidator;
    }

    public void Add(Criterion criterion)
    {
        _criterionValidator.Validate(criterion, false);
        _criterionRepository.AddCriterion(criterion);
    }

    public IEnumerable<Criterion> GetAll()
    {
        return _criterionRepository.GetCriteria();
    }

    public void Update(Criterion criterion)
    {
        _criterionValidator.Validate(criterion, true);
        _criterionRepository.UpdateCriterion(criterion);
    }

    public void Delete(int id)
    {
        _hostelCriterionValueRepository.DeleteHostelCriterionValueByCriterionId(id);
        _criterionRepository.DeleteCriterion(id);
    }
}