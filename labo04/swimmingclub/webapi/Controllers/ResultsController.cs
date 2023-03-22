using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Results;
using System.Runtime.InteropServices;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultRepository _resultRepository;

        public ResultsController(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        [HttpGet]
        [Consumes("application/json")]
        public async Task<ActionResult<GetResultModel>> GetResults()
        {
            List<GetResultModel> results = await _resultRepository.GetResults();
            return results == null ? NotFound() : Ok(results);
        }

        [HttpGet("Search")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetResultModel>> GetResult(Guid swimmerid, Guid raceid)
        {
            GetResultModel result = await _resultRepository.GetResultByIds(swimmerid, raceid);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<GetResultModel>> PostResult(PostResultModel postResultModel)
        {
            GetResultModel result = await _resultRepository.PostResult(postResultModel);
            return CreatedAtAction("GetResult", new { swimmerid = result.SwimmerId, raceid = result.RaceId }, result);
        }
    }
}
