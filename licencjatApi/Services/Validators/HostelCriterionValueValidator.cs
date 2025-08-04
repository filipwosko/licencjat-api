using licencjatApi.Models;
using licencjatApi.Repository;

namespace licencjatApi.Services.Validators
{
    public class HostelCriterionValueValidator : IHostelCriterionValueValidator
    {
        readonly ICriterionRepository _criterionRepository;
        readonly IMountainHostelRepository _mountainHostelRepository;
        readonly IHostelCriterionValueRepository _hostelCriterionValueRepository;

        public HostelCriterionValueValidator(
            ICriterionRepository criterionRepository,
            IMountainHostelRepository mountainHostelRepository,
            IHostelCriterionValueRepository hostelCriterionValueRepository
            )
        {
            _criterionRepository = criterionRepository;
            _mountainHostelRepository = mountainHostelRepository;
            _hostelCriterionValueRepository = hostelCriterionValueRepository;
        }

        //    public class HostelCriterionValue
        //    {
        //        public int MountainHostelId { get; set; }
        //        public int CriterionId { get; set; }
        //        public decimal Value { get; set; }
        //    }

        public void Validate(HostelCriterionValue hostelCriterionValue, bool isUpdate)
        {
            var hCV = _hostelCriterionValueRepository
                .GetByHostelIdAndCriterionId(hostelCriterionValue.MountainHostelId, hostelCriterionValue.CriterionId);

            if (isUpdate && !hCV.Any())
                throw new NotValidObjectDataException("Nie można modyfikować nieistniejącej wartości.");

            if (!isUpdate && hCV.Any())
                throw new NotValidObjectDataException("Dla schroniska dodano już wartość względem kryterium.");

            //var value = hostelCriterionValue.Value;

            var criterionType = _criterionRepository.GetCriteria().FirstOrDefault(c => c.Id == hostelCriterionValue.CriterionId).Type;
            switch (criterionType)
            {
                case CriterionType.DecimalValue:
                    break;
                case CriterionType.YesNo:
                    var value = hostelCriterionValue.Value;
                    if (value != 0 && value != 1)
                        throw new NotValidObjectDataException("Niepoprawna wartość dla kryterium typu Tak/Nie.");
                    break;
                _:
                    throw new NotValidObjectDataException("Niepoprawnie określony typ kryterium.");
            }
        }
    }
}
