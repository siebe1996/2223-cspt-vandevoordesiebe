using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.SwimmingPools;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwimmingPoolsController : ControllerBase
    {
        private readonly ISwimmingPoolRepository _swimmingPoolRepository;

        public SwimmingPoolsController(ISwimmingPoolRepository swimmingPoolRepository)
        {
            _swimmingPoolRepository = swimmingPoolRepository;
        }

        [HttpGet]
        [Consumes("application/json")]
        public async Task<ActionResult<GetSwimmingPoolModel>> GetSwimmingPools()
        {
            var models = await _swimmingPoolRepository.GetSwimmingPools();
            return models == null ? NotFound() : Ok(models);
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetSwimmingPoolModel>> GetSwimmingPool(Guid id)
        {
            var model = await _swimmingPoolRepository.GetSwimmingPool(id);
            return model == null ? NotFound() : Ok(model);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<GetSwimmingPoolModel>> PostSwimmingPool(PostSwimmingPoolModel postSwimmingPoolModel)
        {
            GetSwimmingPoolModel getSwimmingPoolModel = await _swimmingPoolRepository.PostSwimmingPool(postSwimmingPoolModel);
            return CreatedAtAction("GetSwimmingPool", new { id = getSwimmingPoolModel.Id }, getSwimmingPoolModel);
        }
    }
}
