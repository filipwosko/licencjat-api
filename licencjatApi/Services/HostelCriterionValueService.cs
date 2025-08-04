using licencjatApi.Models;
using licencjatApi.Repository;
using licencjatApi.Services.Validators;

namespace licencjatApi.Services
{
    public class HostelCriterionValueService : IHostelCriterionValueService
    {
        private readonly IHostelCriterionValueRepository _hostelCriterionValueRepository;
        private readonly IHostelCriterionValueValidator _hostelCriterionValueValidator;
        public HostelCriterionValueService(
            IHostelCriterionValueRepository hostelCriterionValueRepository, 
            IHostelCriterionValueValidator hostelCriterionValueValidator
            )
        {
            _hostelCriterionValueRepository = hostelCriterionValueRepository;
            _hostelCriterionValueValidator = hostelCriterionValueValidator;
        }

        public void Add(HostelCriterionValue hostelCriterionValue)
        {
            _hostelCriterionValueValidator.Validate(hostelCriterionValue, false);
            _hostelCriterionValueRepository.AddHostelCriterionValue(hostelCriterionValue);
        }

        public void Delete(int id)
        {
            _hostelCriterionValueRepository.DeleteHostelCriterionValue(id);
        }

        public void Update(HostelCriterionValue hostelCriterionValue)
        {
            _hostelCriterionValueValidator.Validate(hostelCriterionValue, true);
            _hostelCriterionValueRepository.UpdateHostelCriterionValue(hostelCriterionValue);
        }
    }
}
