using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Entities
{
    public class Swimmer : Member
    {
        private List<Workout> _workouts = new List<Workout>();
        public int FinaPoints { get; set; }
        public List<Workout> Workouts { get { return _workouts; } set { _workouts = value; } }

        public Swimmer() { }

        public Swimmer(DateTime dateOfBirth, string firstName, string lastName, char gender, int finaPoints) : base(dateOfBirth, firstName, lastName, gender)
        {
            this.FinaPoints = finaPoints;
        }

        public void AddWorkout(Workout workout)
        {
            Workouts.Add(workout);
        }

        public void AddWorkouts(List<Workout> workouts)
        {
            Workouts.AddRange(workouts);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
