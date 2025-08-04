using licencjatApi.Models;
using licencjatApi.Models.DTOs;
using licencjatApi.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace licencjatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramParametersController : ControllerBase
    {
        private readonly IProgramParametersService _programParametersService;

        public ProgramParametersController(IProgramParametersService programParametersService)
        {
            _programParametersService = programParametersService;
        }

        [HttpPut("Update")]
        [SwaggerOperation(
            Summary = "Określa algorytm do rankingu",
            Description = "Metoda określająca rodzaj algorytmu wykorzystywanego do generowania rankingu"
        )]
        public IActionResult Update(ProgramParameterDto parameterDto)
        {
            try
            {
                _programParametersService.Update(parameterDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
