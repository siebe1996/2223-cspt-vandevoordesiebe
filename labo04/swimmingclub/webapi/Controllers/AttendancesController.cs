using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Attendances;

namespace webapi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendancesController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        [HttpGet]
        [Consumes("application/json")]
        public async Task<ActionResult<GetAttendanceModel>> GetAttendances()
        {
            List<GetAttendanceModel> results = await _attendanceRepository.GetAttendances();
            return results == null ? NotFound() : Ok(results);
        }

        [HttpGet("Search")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetAttendanceModel>> GetAttendance(Guid workoutid, Guid swimmerid)
        {
            GetAttendanceModel result = await _attendanceRepository.GetAttendanceByIds(workoutid,swimmerid);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<GetAttendanceModel>> PostAttendance(PostAttendanceModel postAttendanceModel)
        {
            GetAttendanceModel result = await _attendanceRepository.PostAttendance(postAttendanceModel);
            return CreatedAtAction("GetAttendance", new { workoutid = result.WorkoutId, swimmerid = result.SwimmerId }, result);
        }
    }
}
