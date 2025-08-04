using licencjatApi.Models;

namespace licencjatApi.Services.Validators
{
    public interface IMountainHostelValidator
    {
        void Validate(MountainHostel hostel, bool isUpdate);
    }
}
