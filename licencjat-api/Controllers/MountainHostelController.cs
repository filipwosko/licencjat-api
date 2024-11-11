using licencjat_api.Models;
using Microsoft.AspNetCore.Mvc;
using licencjat_api.Services;

namespace licencjat_api.Controllers
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
        public IEnumerable<MountainHostel> GetAll()
        {
            return _mountainHostelService.GetAll();
        }

        [HttpGet("Get/{id}")]
        public MountainHostel Get(int id)
        {
            return _mountainHostelService.Get(id);
        }

        [HttpPost("Add")]
        public void Add(MountainHostel mountainHostel)
        {
            _mountainHostelService.Add(mountainHostel);
        }

        [HttpPut("Update")]
        public void Update(MountainHostel mountainHostel)
        {
            _mountainHostelService.Update(mountainHostel);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _mountainHostelService.Delete(id);
        }
    }
}
