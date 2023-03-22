﻿using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Swimmers;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwimmersController : ControllerBase
    {
        private readonly ISwimmerRepository _swimmerRepository;

        public SwimmersController(ISwimmerRepository swimmerRepository)
        {
            _swimmerRepository = swimmerRepository;
        }

        [HttpGet]
        [Consumes("application/json")]
        public async Task<ActionResult<GetSwimmerModel>> GetSwimmers()
        {
            var models = await _swimmerRepository.GetSwimmers();
            return models == null ? NotFound() : Ok(models);
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetSwimmerModel>> GetSwimmer(Guid id)
        {
            var model = await _swimmerRepository.GetSwimmer(id);
            return model == null ? NotFound() : Ok(model);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<GetSwimmerModel>> PostSwimmer(PostSwimmerModel postSwimmerModel)
        {
            GetSwimmerModel getSwimmerModel = await _swimmerRepository.PostSwimmer(postSwimmerModel);
            return CreatedAtAction("GetSwimmer", new { id = getSwimmerModel.Id }, getSwimmerModel);
        }
    }
}
