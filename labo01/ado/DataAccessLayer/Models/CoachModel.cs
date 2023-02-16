using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CoachModel : MemberModel
    {
        private List<WorkoutModel> _workouts;
        public CoachLevelModel Level { get; }
        public List<WorkoutModel> Workouts { get { return _workouts; } set { _workouts = value; } }

        public CoachModel(int id, DateTime dateOfBirth, string firstName, string lastName, char gender, CoachLevelModel level) : base(id, dateOfBirth, firstName, lastName, gender)
        {
            this.Level = level;
        }

        public CoachModel(int id, DateTime dateOfBirth, string firstName, string lastName, char gender, CoachLevelModel level, List<WorkoutModel> workouts) : base(id, dateOfBirth, firstName, lastName, gender)
        {
            this.Level = level;
            this.Workouts = workouts;
        }

        public void AddWorkout(WorkoutModel workout)
        {
            Workouts.Add(workout);
        }

        public void AddWorkouts(List<WorkoutModel> workouts)
        {
            Workouts.AddRange(workouts);
        }

    }
}
