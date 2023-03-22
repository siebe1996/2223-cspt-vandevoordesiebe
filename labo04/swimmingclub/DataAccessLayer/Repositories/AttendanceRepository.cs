using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.EntityFrameworkCore;
using models.Attendances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly SwimmingClubContext _context;

        public AttendanceRepository(SwimmingClubContext context)
        {
            _context = context;
        }

        public async Task<List<GetAttendanceModel>> GetAttendances()
        {
            List<GetAttendanceModel> attendances = await _context.Attendances.Select(x => new GetAttendanceModel
            {
                SwimmerId = x.SwimmerId,
                WorkoutId = x.WorkoutId,
                Present = x.Present,
                Remark = x.Remark,
            }).AsNoTracking()
            .ToListAsync();

            return attendances;
        }

        public async Task<List<GetAttendanceModel>> GetAttendancesBySwimmerId (Guid id)
        {
            List<GetAttendanceModel> attendances = await _context.Attendances.Select(x => new GetAttendanceModel
            {
                SwimmerId = x.SwimmerId,
                WorkoutId = x.WorkoutId,
                Present = x.Present,
                Remark = x.Remark,
            }).AsNoTracking()
            .Where(x => x.SwimmerId == id)
            .ToListAsync();

            return attendances;
        }


        public async Task<List<GetAttendanceModel>> GetAttendancesByWorkoutId(Guid id)
        {
            List<GetAttendanceModel> attendances = await _context.Attendances.Select(x => new GetAttendanceModel
            {
                SwimmerId = x.SwimmerId,
                WorkoutId = x.WorkoutId,
                Present = x.Present,
                Remark = x.Remark,
            }).AsNoTracking()
            .Where(x => x.WorkoutId == id)
            .ToListAsync();

            return attendances;
        }

        public async Task<GetAttendanceModel> GetAttendanceByIds(Guid workoutId, Guid swimmerId)
        {
            GetAttendanceModel attendance = await _context.Attendances.Select(x => new GetAttendanceModel
            {
                SwimmerId = x.SwimmerId,
                WorkoutId = x.WorkoutId,
                Present = x.Present,
                Remark = x.Remark,
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.WorkoutId == workoutId && x.SwimmerId == swimmerId);

            return attendance;
        }

        public async Task<GetAttendanceModel> PostAttendance (PostAttendanceModel postAttendanceModel)
        {
            Attendance attendance = new Attendance
            {
                SwimmerId = postAttendanceModel.SwimmerId,
                WorkoutId = postAttendanceModel.WorkoutId,
                Present = postAttendanceModel.Present,
                Remark = postAttendanceModel.Remark,
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            GetAttendanceModel getAttendanceModel = new GetAttendanceModel 
            { 
                SwimmerId = attendance.SwimmerId,
                WorkoutId = attendance.WorkoutId,
                Present = attendance.Present,
                Remark = attendance.Remark,
            };

            return getAttendanceModel;
        }

    }
}
