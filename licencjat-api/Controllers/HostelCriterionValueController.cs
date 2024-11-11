using licencjat_api.Models;
using Microsoft.AspNetCore.Mvc;
using licencjat_api.Services;

namespace licencjat_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HostelCriterionValueController : ControllerBase
    {
        private readonly IHostelCriterionValueService _hostelCriterionValueService;

        public HostelCriterionValueController(IHostelCriterionValueService HostelCriterionValueService)
        {
            _hostelCriterionValueService = HostelCriterionValueService;
        }

        [HttpGet("GetByHostelId/{hostelId}")]
        public IEnumerable<HostelCriterionValue> GetByHostelId(int hostelId)
        {
            return _hostelCriterionValueService.GetByHostelId(hostelId);
        }

        [HttpGet("GetByCriterionId/{criterionId}")]
        public IEnumerable<HostelCriterionValue> GetByCriterionId(int criterionId)
        {
            return _hostelCriterionValueService.GetByHostelId(criterionId);
        }

        [HttpPost("Add")]
        public void Add(HostelCriterionValue HostelCriterionValue)
        {
            _hostelCriterionValueService.Add(HostelCriterionValue);
        }

        [HttpPut("Update")]
        public void Update(HostelCriterionValue HostelCriterionValue)
        {
            _hostelCriterionValueService.Update(HostelCriterionValue);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _hostelCriterionValueService.Delete(id);
        }
    }
}