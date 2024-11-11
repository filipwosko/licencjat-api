using licencjat_api.Models;

namespace licencjat_api.Services;

public interface IMountainHostelService
{
    void Add(MountainHostel hostel);
    IEnumerable<MountainHostel> GetAll();
    MountainHostel Get(int id);
    void Update(MountainHostel mountainHostel);
    void Delete(int id);
}