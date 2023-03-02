using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.Warning.Types;

namespace Globals.Entities
{
    [Table("Coaches")]
    public class Coach : Member
    {
        private List<Workout> _workouts = new List<Workout>();
        public CoachLevel Level { get; set; }
        public virtual List<Workout> Workouts { get { return _workouts; } set { _workouts = value;  } }

        public Coach(DateTime dateOfBirth, string firstName, string lastName, char gender, CoachLevel level) : base(dateOfBirth, firstName, lastName, gender)
        {
            this.Level = level;
        }

        public Coach(DateTime dateOfBirth, string firstName, string lastName, char gender, int id, CoachLevel level) : base(dateOfBirth, firstName, lastName, gender, id)
        {
            this.Level = level;
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
