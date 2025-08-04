using licencjatApi.Models;
using Microsoft.AspNetCore.Mvc;
using licencjatApi.Services;
using licencjatApi.Models.DTOs;
using licencjatApi.Services.Validators;
using Swashbuckle.AspNetCore.Annotations;

namespace licencjatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriterionController : ControllerBase
    {
        private readonly ICriterionService _criterionService;

        public CriterionController(ICriterionService criterionService)
        {
            _criterionService = criterionService;
        }

        [HttpPost("Add")]
        [SwaggerOperation(
            Summary = "Dodaje nowe kryterium",
            Description = "Metoda dodająca nowe kryterium do systemu"
        )]
        public IActionResult Add(CriterionDto criterion)
        {
            try
            {
                Criterion criterionToAdd = new Criterion()
                {
                    Name = criterion.Name,
                    Type = criterion.Type,
                    IsStimulant = criterion.IsStimulant
                };

                _criterionService.Add(criterionToAdd);
            }
            catch (NotValidObjectDataException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("Update")]
        [SwaggerOperation(
            Summary = "Aktualizuje kryterium",
            Description = "Metoda aktualizująca dane istniejącego kryterium"
        )]
        public IActionResult Update(CriterionDto criterion)
        {
            try
            {
                Criterion criterionToUpdate = new Criterion()
                {
                    Id = criterion.Id,
                    Name = criterion.Name,
                    Type = criterion.Type,
                    IsStimulant = criterion.IsStimulant
                };

                _criterionService.Update(criterionToUpdate);
            }
            catch (NotValidObjectDataException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("Delete{id}")]
        [SwaggerOperation(
            Summary = "Usuwa kryterium",
            Description = "Metoda usuwająca kaskadowo kryterium - wraz z wartościami usuwanego kryterium dla schronisk"
        )]
        public void Delete(int id)
        {
            _criterionService.Delete(id);
        }

        [HttpGet("Get")]
        [SwaggerOperation(
            Summary = "Zwraca listę kryteriów",
            Description = "Metoda zwracająca listę kryteriów"
        )]
        [EndpointDescription("Metoda zwracająca listę kryteriów")]
        public CriteriaDto Get()
        {
            return new CriteriaDto()
            {
                Criteria = _criterionService.GetAll()
            };
        }
    }
}