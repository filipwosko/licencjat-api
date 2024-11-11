using licencjat_api.Models;

namespace licencjat_api.Services;

public interface ICriterionService
{
    void Add(Criterion hostel);
    IEnumerable<Criterion> GetAll();
    void Update(Criterion Criterion);
    void Delete(int id);
}