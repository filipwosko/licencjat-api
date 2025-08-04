using licencjatApi.Models;
using Microsoft.AspNetCore.Mvc;
using licencjatApi.Services;
using licencjatApi.Models.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace licencjatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HostelCriterionValueController : ControllerBase
    {
        private readonly IHostelCriterionValueService _hostelCriterionValueService;

        public HostelCriterionValueController(IHostelCriterionValueService hostelCriterionValueService)
        {
            _hostelCriterionValueService = hostelCriterionValueService;
        }

        [HttpPost("Add")]
        [SwaggerOperation(
            Summary = "Dodaje wartość kryterium",
            Description = "Metoda dodająca wartość kryterium dla schroniska"
        )]
        public void Add(HostelCriterionValueAddDto hostelCriterionValue)
        {
            _hostelCriterionValueService.Add(new HostelCriterionValue()
            {
                MountainHostelId = hostelCriterionValue.MountainHostelId,
                CriterionId = hostelCriterionValue.CriterionId,
                Value = hostelCriterionValue.Value
            });
        }

        [HttpPut("Update")]
        [SwaggerOperation(
            Summary = "Aktualizuje wartość kryterium",
            Description = "Metoda aktualizująca wartość kryterium dla schroniska"
        )]
        public void Update(HostelCriterionValueUpdateDto hostelCriterionValue)
        {
            _hostelCriterionValueService.Update(new HostelCriterionValue()
            {
                Id = hostelCriterionValue.Id,
                Value = hostelCriterionValue.Value
            });
        }

        [HttpDelete("Delete")]
        [SwaggerOperation(
            Summary = "Usuwa wartość kryterium",
            Description = "Metoda usuwająca wartość kryterium dla schroniska"
        )]
        public void Delete(int id)
        {
            _hostelCriterionValueService.Delete(id);
        }
    }
}