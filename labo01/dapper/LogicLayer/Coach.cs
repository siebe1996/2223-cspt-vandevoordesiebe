using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Coach : Member
    {
        private List<Workout> _workouts;
        public CoachLevel Level { get; }
        public List<Workout> Workouts { get { return _workouts; } set { _workouts = value;  } }

        public Coach(CoachModel coach) : base(coach.DateOfBirth, coach.FirstName, coach.LastName, coach.Gender, coach.Id)
        {
            this.Level = (CoachLevel)coach.Level;
            //this.Workouts = coach.Workouts.Cast<Workout>().ToList();
            this.Workouts = new List<Workout>(coach.Workouts.Select(w =>  new Workout(w)));
        }

        public Coach(DateTime dateOfBirth, string firstName, string lastName, char gender, int id, CoachLevel level, List<Workout> workouts) : base(dateOfBirth, firstName, lastName, gender, id) 
        { 
            this.Level = level;
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
