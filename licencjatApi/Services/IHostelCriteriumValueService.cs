using licencjatApi.Models;

namespace licencjatApi.Services;

public interface IHostelCriterionValueService
{
    void Add(HostelCriterionValue hostelCriterionValue);
    //IEnumerable<HostelCriterionValue> GetByHostelId(int id);
    //IEnumerable<HostelCriterionValue> GetByCriterionId(int id);
    void Update(HostelCriterionValue hostelCriterionValue);
    void Delete(int id);
}