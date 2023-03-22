using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Races;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {
        private readonly IRaceRepository _raceRepository;

        public RacesController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }

        [HttpGet]
        [Consumes("application/json")]
        public async Task<ActionResult<GetRaceModel>> GetRaces()
        {
            var models = await _raceRepository.GetRaces();
            return models == null ? NotFound() : Ok(models);
        }

        [HttpGet]
        [Route("Results")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetRaceResultModel>> GetRaceResults()
        {
            List<GetRaceResultModel> models = await _raceRepository.GetRacesResults();
            return models == null ? NotFound() : Ok(models);
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetRaceModel>> GetRace(Guid id)
        {
            var model = await _raceRepository.GetRace(id);
            return model == null ? NotFound() : Ok(model);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<GetRaceModel>> PostRace(PostRaceModel postRaceModel)
        {
            GetRaceModel getRaceModel = await _raceRepository.PostRace(postRaceModel);
            return CreatedAtAction("GetRace", new { id = getRaceModel.Id }, getRaceModel);
        }
    }
}
