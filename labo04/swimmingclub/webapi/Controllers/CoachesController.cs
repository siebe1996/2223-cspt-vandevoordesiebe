using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Coaches;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly ICoachRepository _coachRepository;

        public CoachesController(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }

        [HttpGet]
        [Consumes("application/json")]
        public async Task<ActionResult<GetCoachModel>> GetCoaches()
        {
            var models =  await _coachRepository.GetCoaches();
            return models == null ? NotFound() : Ok(models);
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetCoachModel>> GetCoach(Guid id)
        {
            var model = await _coachRepository.GetCoach(id);
            return model == null ? NotFound() : Ok(model);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<GetCoachModel>> PostCoach(PostCoachModel postCoachModel)
        {
            GetCoachModel getCoachModel = await _coachRepository.PostCoach(postCoachModel);
            return CreatedAtAction("GetCoach", new { id = getCoachModel.Id }, getCoachModel);
        }
    }
}
