using licencjatApi.Models;
using licencjatApi.Models.DTOs;

namespace licencjatApi.Services
{
    public interface IProgramParametersService
    {
        void Update(ProgramParameterDto parameterDto);
    }
}
