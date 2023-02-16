using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class SwimmerModel : MemberModel
    {
        private List<WorkoutModel> _workouts;
        public int FinaPoints { get; }
        public List<WorkoutModel> Workouts { get { return _workouts; } set { _workouts = value; } }

        public SwimmerModel(int id, DateTime dateOfBirth, string firstName, string lastName, char gender, int finaPoints) : base(id, dateOfBirth, firstName, lastName, gender) 
        { 
            this.FinaPoints = finaPoints;
        }

        public SwimmerModel(int id, DateTime dateOfBirth, string firstName, string lastName, char gender, int finaPoints, List<WorkoutModel> workouts) : base(id, dateOfBirth, firstName, lastName, gender)
        {
            this.FinaPoints = finaPoints;
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
