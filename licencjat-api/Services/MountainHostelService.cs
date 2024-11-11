using licencjat_api.Models;
using licencjat_api.Repository;

namespace licencjat_api.Services;

public class MountainHostelService : IMountainHostelService
{
    private readonly IMountainHostelRepository _mountainHostelRepository;

    public MountainHostelService(IMountainHostelRepository mountainHostelRepository)
    {
        _mountainHostelRepository = mountainHostelRepository;
    }

    public void Add(MountainHostel hostel)
    {
        _mountainHostelRepository.AddMountainHostel(hostel);
    }

    public IEnumerable<MountainHostel> GetAll()
    {
        return _mountainHostelRepository.GetMountainHostels();
    }

    public MountainHostel Get(int id)
    {
        return _mountainHostelRepository.GetMountainHostel(id);
    }

    public void Update(MountainHostel mountainHostel)
    {
        _mountainHostelRepository.UpdateMountainHostel(mountainHostel);
    }

    public void Delete(int id)
    {
        _mountainHostelRepository.DeleteMountainHostel(id);
    }
}