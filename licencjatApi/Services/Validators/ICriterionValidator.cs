using licencjatApi.Models;

namespace licencjatApi.Services.Validators
{
    public interface ICriterionValidator
    {
        void Validate(Criterion criterion, bool isUpdate);
    }
}
