using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Races;
using models.Workouts;

namespace webapi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutsController(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        [HttpGet]
        [Consumes("application/json")]
        public async Task<ActionResult<GetWorkoutModel>> GetWorkouts()
        {
            List<GetWorkoutModel> models = await _workoutRepository.GetWorkouts();
            return models == null ? NotFound() : Ok(models);
        }

        [HttpGet]
        [Route("Absences")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetWorkoutAbsenceModel>> GetWorkoutsAbsences()
        {
            List<GetWorkoutAbsenceModel> models = await _workoutRepository.GetWorkoutsAbsences();
            return models == null ? NotFound() : Ok(models);
        }

        [HttpGet]
        [Route("Attendance")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetWorkoutAbsenceModel>> GetWorkoutsAttendance()
        {
            List<GetWorkoutAbsenceModel> models = await _workoutRepository.GetWorkoutsAttendance();
            return models == null ? NotFound() : Ok(models);
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetWorkoutModel>> GetWorkOut(Guid id)
        {
            GetWorkoutModel model = await _workoutRepository.GetWorkout(id);
            return model == null ? NotFound() : Ok(model);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<GetWorkoutModel>> PostWorkout(PostWorkoutModel postWorkoutModel)
        {
            GetWorkoutModel model = await _workoutRepository.PostWorkout(postWorkoutModel);
            return CreatedAtAction("GetWorkout", new { id = model.Id }, model);
        }
    }
}
