using licencjat_api.Models;

namespace licencjat_api.Services;

public interface IHostelCriterionValueService
{
    void Add(HostelCriterionValue hostel);
    IEnumerable<HostelCriterionValue> GetByHostelId(int id);
    IEnumerable<HostelCriterionValue> GetByCriterionId(int id);
    void Update(HostelCriterionValue HostelCriterionValue);
    void Delete(int id);
}