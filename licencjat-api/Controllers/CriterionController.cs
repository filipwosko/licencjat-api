using licencjat_api.Models;
using Microsoft.AspNetCore.Mvc;
using licencjat_api.Services;

namespace licencjat_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriterionController : ControllerBase
    {
        private readonly ICriterionService _criterionService;

        public CriterionController(ICriterionService CriterionService)
        {
            _criterionService = CriterionService;
        }

        [HttpPost("Add")]
        public void Add(Criterion Criterion)
        {
            _criterionService.Add(Criterion);
        }

        [HttpPut("Update")]
        public void Update(Criterion Criterion)
        {
            _criterionService.Update(Criterion);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _criterionService.Delete(id);
        }
    }
}