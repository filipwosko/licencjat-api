using licencjatApi.Models;
using licencjatApi.Repository;

namespace licencjatApi.Services.Validators
{
    public class CriterionValidator : ICriterionValidator
    {
        private readonly ICriterionRepository _criterionRepository;

        public CriterionValidator(ICriterionRepository criterionRepository)
        {
            _criterionRepository = criterionRepository;
        }

        public void Validate(Criterion criterion, bool isUpdate)
        {
            if (string.IsNullOrEmpty(criterion.Name))
                throw new NotValidObjectDataException("Nazwa kryterium nie może być pusta.");

            if (!Enum.IsDefined(typeof(CriterionType), criterion.Type))
                throw new NotValidObjectDataException("Nieprawidłowy typ kryterium.");

            if (isUpdate)
            {
                if (_criterionRepository.GetCriteria().Any(c => c.Name == criterion.Name && c.Id != criterion.Id))
                    throw new NotValidObjectDataException("Nazwa kryterium jest już zajęta.");
            }
            else
            {
                if (_criterionRepository.GetCriteria().Any(c => c.Name == criterion.Name))
                    throw new NotValidObjectDataException("Nazwa kryterium jest już zajęta.");
            }
        }
    }
}
