using licencjatApi.Models;

namespace licencjatApi.Repository
{
    public interface IHostelCriterionValueRepository
    {
        IEnumerable<HostelCriterionValue> GetByHostelIdAndCriterionId(int hostelId, int criterionId); 
        IEnumerable<HostelCriterionValue> GetByHostelId(int hostelId);
        IEnumerable<HostelCriterionValue> GetByCriterionId(int criterionId);
        void AddHostelCriterionValue(HostelCriterionValue hostelCriterionValue);
        void UpdateHostelCriterionValue(HostelCriterionValue hostelCriterionValue);
        void DeleteHostelCriterionValue(int id);
        void DeleteHostelCriterionValueByHostelId(int hostelId);
        void DeleteHostelCriterionValueByCriterionId(int criterionId);
    }
}
