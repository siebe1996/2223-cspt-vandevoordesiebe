using models.Workouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.interfaces
{
    public interface IWorkoutRepository
    {
        Task<List<GetWorkoutModel>> GetWorkouts();
        Task<List<GetWorkoutAbsenceModel>> GetWorkoutsAbsences();
        Task<List<GetWorkoutAbsenceModel>> GetWorkoutsAttendance();
        Task<GetWorkoutModel> GetWorkout(Guid id);
        Task<GetWorkoutModel> PostWorkout(PostWorkoutModel postWorkoutModel);
    }
}
