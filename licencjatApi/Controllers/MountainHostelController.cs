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
    public class MountainHostelController : ControllerBase
    {
        private readonly IMountainHostelService _mountainHostelService;

        public MountainHostelController(IMountainHostelService mountainHostelService)
        {
            _mountainHostelService = mountainHostelService;
        }

        [HttpGet("GetAll")]
        [SwaggerOperation(
            Summary = "Zwraca list� schronisk",
            Description = "Metoda zwracaj�ca list� schronisk"
        )]
        public IEnumerable<MountainHostel> GetAll()
        {
            return _mountainHostelService.GetAll();
        }

        [HttpGet("Get/{id}")]
        [SwaggerOperation(
            Summary = "Zwraca schronisko o podanym id",
            Description = "Metoda zwracaj�ca schronisko o podanym id"
        )]
        public MountainHostel Get(int id)
        {
            return _mountainHostelService.Get(id);
        }

        [HttpPost("Add")]
        [SwaggerOperation(
            Summary = "Dodaje schronisko",
            Description = "Metoda dodaj�ca schronisko"
        )]
        public IActionResult Add(MountainHostelDto mountainHostel)
        {
            try
            {
                MountainHostel hostel = new MountainHostel()
                {
                    Name = mountainHostel.Name
                };

                _mountainHostelService.Add(hostel);
            }
            catch(NotValidObjectDataException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("Update")]
        [SwaggerOperation(
            Summary = "Aktualizuje schronisko",
            Description = "Metoda aktualizuj�ca schronisko"
        )]
        public IActionResult Update(MountainHostelDto mountainHostel)
        {
            try
            {
                var idhostelu = mountainHostel.Id;
                MountainHostel hostel = new MountainHostel()
                {
                    Name = mountainHostel.Name,
                    Id = mountainHostel.Id
                };
                _mountainHostelService.Update(hostel);
            }
            catch (NotValidObjectDataException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("Delete{id}")]
        [SwaggerOperation(
            Summary = "Usuwa schronisko",
            Description = "Metoda usuwaj�ca kaskadowo  schronisko - wraz z warto�ciami usuwanego schroniska wzgl�dem kryteri�w"
        )]
        public void Delete(int id)
        {
            _mountainHostelService.Delete(id);
        }
    }
}
