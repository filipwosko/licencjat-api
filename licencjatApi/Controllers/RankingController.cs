using licencjatApi.Models;
using licencjatApi.Models.DTOs;
using licencjatApi.Services;
using licencjatApi.Services.Ranking;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace licencjatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankingController : ControllerBase
    {
        private readonly IRankingService _rankingService;
        private readonly ICriterionService _criterionService;

        public RankingController(IRankingService rankingService, ICriterionService criterionService)
        {
            _rankingService = rankingService;
            _criterionService = criterionService;
        }

        [HttpPost("GetRanking")]
        [SwaggerOperation(
            Summary = "Zwraca ranking schronisk",
            Description = "Metoda zwracająca ranking schronisk"
        )]
        public RankingDto Get(IEnumerable<CriterionWeight> criterionWeights)
        {
            return _rankingService.GetRanking(criterionWeights);
        }

        [HttpGet("GetCriteriaForRanking")]
        [SwaggerOperation(
            Summary = "Zwraca kryteria do rankingu",
            Description = "Metoda zwracająca kryteria wraz z ich właściwościami potrzebnymi do określenia rankingu"
        )]
        public IEnumerable<CriterionDto> GetCriteriaForRanking()
        {
            return _criterionService.GetAll().Select(x => new CriterionDto()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                IsStimulant = x.IsStimulant,
            });
        }
    }
}