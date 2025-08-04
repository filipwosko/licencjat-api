using licencjatApi.Models;

namespace licencjatApi.Services;

public interface ICriterionService
{
    void Add(Criterion hostel);
    IEnumerable<Criterion> GetAll();
    void Update(Criterion Criterion);
    void Delete(int id);
}