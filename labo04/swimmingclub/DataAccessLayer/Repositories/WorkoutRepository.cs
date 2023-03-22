﻿using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.EntityFrameworkCore;
using models.Workouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly SwimmingClubContext _context;

        public WorkoutRepository(SwimmingClubContext context)
        {
            _context = context;
        }

        public async Task<List<GetWorkoutModel>> GetWorkouts()
        {
            List<GetWorkoutModel> workouts = await _context.Workouts.Select(x => new GetWorkoutModel
            {
                Id = x.Id,
                SwimmingPoolId = x.SwimmingPoolId,
                CoachId = x.CoachId,
                Schedule = x.Schedule,
                WorkoutType = x.WorkoutType,
                Duration = x.Duration,
            }).AsNoTracking()
            .ToListAsync();

            return workouts;
        }

        public async Task<List<GetWorkoutAbsenceModel>> GetWorkoutsAbsences()
        {
            List<GetWorkoutAbsenceModel> workoutsAbsences = await _context.Workouts.Where(x => x.Schedule < DateTime.Now)
                .Select(x => new GetWorkoutAbsenceModel
            {
                Schedulde = x.Schedule,
                CoachFullName = $"{x.Coach.FirstName} {x.Coach.LastName}",
                SwimmerNames = x.Attendences.Where(x => x.Present == false).Select(x => $"{x.Swimmer.FirstName} {x.Swimmer.LastName}").ToList(),
            }).Where(x => x.SwimmerNames.Any()).AsNoTracking()
            .ToListAsync();

            return workoutsAbsences;
        }

        public async Task<GetWorkoutModel> GetWorkout(Guid id)
        {
            GetWorkoutModel workout = await _context.Workouts
            .Where(x => x.Id == id)
            .Select(x => new GetWorkoutModel
            {
                Id = x.Id,
                SwimmingPoolId = x.SwimmingPoolId,
                CoachId = x.CoachId,
                Schedule = x.Schedule,
                WorkoutType = x.WorkoutType,
                Duration = x.Duration,
            })
            .AsNoTracking()
            .SingleOrDefaultAsync();

            return workout;
        }

        public async Task<GetWorkoutModel> PostWorkout(PostWorkoutModel postWorkoutModel)
        {
            Workout workout = new Workout
            {
                SwimmingPoolId = postWorkoutModel.SwimmingPoolId,
                CoachId = postWorkoutModel.CoachId,
                Schedule = postWorkoutModel.Schedule,
                WorkoutType = postWorkoutModel.WorkoutType,
                Duration = postWorkoutModel.Duration,
            };

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            GetWorkoutModel getWorkoutModel = new GetWorkoutModel
            {
                Id = workout.Id,
                SwimmingPoolId = workout.SwimmingPoolId,
                CoachId = workout.CoachId,
                Schedule = workout.Schedule,
                WorkoutType = workout.WorkoutType,
                Duration = workout.Duration,
            };

            return getWorkoutModel;
        }
    }
}
