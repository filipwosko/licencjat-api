using licencjatApi.Models.DTOs;
using licencjatApi.Repositories;

namespace licencjatApi.Services
{

    public class ProgramParametersService : IProgramParametersService
    {
        private readonly IProgramParametersRepository _programParametersRepository;

        public ProgramParametersService(IProgramParametersRepository programParametersRepository)
        {
            _programParametersRepository = programParametersRepository;
        }

        public void Update(ProgramParameterDto parameterDto)
        {
            _programParametersRepository.MethodName = parameterDto.Value;
        }

    }
}
