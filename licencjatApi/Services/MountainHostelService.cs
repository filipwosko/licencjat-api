using licencjatApi.Models;
using licencjatApi.Repository;
using licencjatApi.Services.Validators;

namespace licencjatApi.Services;

public class MountainHostelService : IMountainHostelService
{
    private readonly IMountainHostelRepository _mountainHostelRepository;
    private readonly IMountainHostelValidator _mountainHostelValidator;
    private readonly IHostelCriterionValueRepository _hostelCriterionValueRepository;

    public MountainHostelService(
        IMountainHostelRepository mountainHostelRepository,
        IMountainHostelValidator mountainHostelValidator,
        IHostelCriterionValueRepository hostelCriterionValueRepository)
    {
        _mountainHostelRepository = mountainHostelRepository;
        _mountainHostelValidator = mountainHostelValidator;
        _hostelCriterionValueRepository = hostelCriterionValueRepository;
    }

    public void Add(MountainHostel mountainHostel)
    {
        _mountainHostelValidator.Validate(mountainHostel, false);
        _mountainHostelRepository.AddMountainHostel(mountainHostel);
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
        _mountainHostelValidator.Validate(mountainHostel, true);
        _mountainHostelRepository.UpdateMountainHostel(mountainHostel);
    }

    public void Delete(int id)
    {
        _hostelCriterionValueRepository.DeleteHostelCriterionValueByHostelId(id);
        _mountainHostelRepository.DeleteMountainHostel(id);
    }
}