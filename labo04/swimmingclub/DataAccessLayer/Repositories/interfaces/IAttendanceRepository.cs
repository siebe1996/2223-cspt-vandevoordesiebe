using models.Attendances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.interfaces
{
    public interface IAttendanceRepository
    {
        Task<List<GetAttendanceModel>> GetAttendances();
        Task<List<GetAttendanceModel>> GetAttendancesBySwimmerId(Guid id);
        Task<List<GetAttendanceModel>> GetAttendancesByWorkoutId(Guid id);
        Task<GetAttendanceModel> GetAttendanceByIds(Guid workouId, Guid swimmerId);
        Task<GetAttendanceModel> PostAttendance(PostAttendanceModel postAttendanceModel);
    }
}
