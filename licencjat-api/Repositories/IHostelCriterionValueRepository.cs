using licencjat_api.Models;

namespace licencjat_api.Repository
{
    public interface IHostelCriterionValueRepository
    {
        IEnumerable<HostelCriterionValue> GetByHostelId();
        IEnumerable<HostelCriterionValue> GetByCriterionId();
        void AddHostelCriterionValue(Criterion Criterion);
        void UpdateHostelCriterionValue(Criterion Criterion);
        void DeleteHostelCriterionValue(int id);
    }
}
