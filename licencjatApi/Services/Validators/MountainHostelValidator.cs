using licencjatApi.Models;
using licencjatApi.Repository;

namespace licencjatApi.Services.Validators
{
    public class MountainHostelValidator : IMountainHostelValidator
    {
        private readonly IMountainHostelRepository _mountainHostelRepository;

        public MountainHostelValidator(IMountainHostelRepository mountainHostelRepository)
        {
            _mountainHostelRepository = mountainHostelRepository;
        }

        public void Validate(MountainHostel hostel, bool isUpdate)
        {
            if (string.IsNullOrEmpty(hostel.Name))
                throw new NotValidObjectDataException("Nazwa schroniska nie może być pusta.");

            if (isUpdate)
            {
                if (_mountainHostelRepository.GetMountainHostels().Any(h => h.Name == hostel.Name && h.Id != hostel.Id))
                    throw new NotValidObjectDataException("Nazwa schroniska jest już zajęta.");
                //if (!_mountainHostelRepository.GetMountainHostels().Any(h => h.Id == hostel.Id))
                //    throw new NotValidObjectDataException("Nie znaleziono schroniska o podanym id.");
            }
            else
            {
                if (_mountainHostelRepository.GetMountainHostels().Any(h => h.Name == hostel.Name))
                    throw new NotValidObjectDataException("Nazwa schroniska jest już zajęta.");
            }
        }
    }
}
