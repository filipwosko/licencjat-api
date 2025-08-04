using licencjatApi.Models;

namespace licencjatApi.Services.Validators
{
    public interface IHostelCriterionValueValidator
    {
        void Validate(HostelCriterionValue hostelCriterionValue, bool isUpdate);
    }
}
