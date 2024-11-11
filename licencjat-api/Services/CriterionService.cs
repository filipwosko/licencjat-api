using licencjat_api.Models;
using licencjat_api.Repository;

namespace licencjat_api.Services;

public class CriterionService : ICriterionService
{
    private readonly ICriterionRepository _criterionRepository;

    public CriterionService(ICriterionRepository CriterionRepository)
    {
        _criterionRepository = CriterionRepository;
    }

    public void Add(Criterion hostel)
    {
        _criterionRepository.AddCriterion(hostel);
    }

    public IEnumerable<Criterion> GetAll()
    {
        return _criterionRepository.GetCriteria();
    }

    public void Update(Criterion Criterion)
    {
        _criterionRepository.UpdateCriterion(Criterion);
    }

    public void Delete(int id)
    {
        _criterionRepository.DeleteCriterion(id);
    }
}