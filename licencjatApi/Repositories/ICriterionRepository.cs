using licencjatApi.Models;

namespace licencjatApi.Repository
{
    public interface ICriterionRepository
    {
        IEnumerable<Criterion> GetCriteria();
        void AddCriterion(Criterion Criterion);
        void UpdateCriterion(Criterion Criterion);
        void DeleteCriterion(int id);
    }
}
