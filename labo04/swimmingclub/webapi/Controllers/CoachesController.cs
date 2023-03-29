using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Coaches;

namespace webapi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetCoachModel>> GetCoaches()
        {
            var models =  await _coachRepository.GetCoaches();
            return models == null ? NotFound() : Ok(models);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetCoachModel>> GetCoach(Guid id)
        {
            var model = await _coachRepository.GetCoach(id);
            return model == null ? NotFound() : Ok(model);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetCoachModel>> PostCoach(PostCoachModel postCoachModel)
        {
            GetCoachModel getCoachModel = await _coachRepository.PostCoach(postCoachModel);
            return CreatedAtAction("GetCoach", new { id = getCoachModel.Id }, getCoachModel);
        }

        [HttpPut("{id}/Roles")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetCoachRolesModel>> AddUserToRole(Guid id, [FromBody] PutCoachRolesModel putCoachRolesModel)
        {
            GetCoachRolesModel getCoachRolesModel = await _coachRepository.AddUserToRole(id, putCoachRolesModel);
            return Ok(getCoachRolesModel);
        }
    }
}
