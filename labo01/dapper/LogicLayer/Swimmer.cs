using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Swimmer : Member
    {
        private List<Workout> _workouts;
        public int FinaPoints { get; }
        public List<Workout> Workouts { get { return _workouts; } set { _workouts = value; } }

        public Swimmer(SwimmerModel swimmer) : base(swimmer.DateOfBirth, swimmer.FirstName, swimmer.LastName, swimmer.Gender, swimmer.Id)
        {
            this.FinaPoints = swimmer.FinaPoints;
            this.Workouts = new List<Workout>(swimmer.Workouts.Select(w => new Workout(w)));
        }

        public Swimmer(DateTime dateOfBirth, string firstName, string lastName, char gender, int id, int finaPoints, List<Workout> workouts) : base(dateOfBirth, firstName, lastName, gender, id)
        {
            this.FinaPoints = finaPoints;
            this.Workouts = workouts;
        }

        public void AddWorkout(Workout workout)
        {
            Workouts.Add(workout);
        }

        public void AddWorkouts(List<Workout> workouts)
        {
            Workouts.AddRange(workouts);
        }
    }
}
