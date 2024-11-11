using licencjat_api.Models;

namespace licencjat_api.Repository
{
    public interface ICriterionRepository
    {
        IEnumerable<Criterion> GetCriteria();
        Criterion GetCriterion(int id);
        void AddCriterion(Criterion Criterion);
        void UpdateCriterion(Criterion Criterion);
        void DeleteCriterion(int id);

    }
}
