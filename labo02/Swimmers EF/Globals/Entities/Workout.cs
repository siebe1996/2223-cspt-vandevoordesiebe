//using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Entities
{
    public class Workout : IComparable<Workout>
    {
        public virtual Coach Coach { get; set; }
        public int Duration { get; set; }
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        public virtual List<Swimmer> Swimmers { get; set; } = new List<Swimmer>();
        public virtual SwimmingPool SwimmingPool { get; set; }
        public WorkoutType Type { get; set; }

        /*public Workout(WorkoutModel workout)
        {
            //Coach = new Coach(workout.Coach); cirkel code
            Duration = workout.Duration;
            Id = workout.Id;
            Schedule = workout.Schedule;
            SwimmingPool = new SwimmingPool(workout.SwimmingPool);
            WorkoutType Type = (WorkoutType)workout.Type;
        }*/

        public Workout()
        {
        }

        public Workout(int duration, DateTime schedule, WorkoutType type)
        {
            Duration = duration;
            Schedule = schedule;
            Type = type;
        }

        public Workout(int duration, DateTime schedule, SwimmingPool swimmingPool, WorkoutType type)
        {
            Duration = duration;
            Schedule = schedule;
            SwimmingPool = swimmingPool;
            Type = type;
        }

        public Workout(int duration, int id, DateTime schedule, WorkoutType type)
        {
            Duration = duration;
            Id = id;
            Schedule = schedule;
            Type = type;
        }

        public Workout(Coach coach, int duration, int id, DateTime schedule, SwimmingPool swimmingPool, WorkoutType type)
        {
            Coach = coach;
            Duration = duration;
            Id = id;
            Schedule = schedule;
            SwimmingPool = swimmingPool;
            Type = type;
        }

        public void AddSwimmer(Swimmer swimmer)
        {
           Swimmers.Add(swimmer);
        }

        public void AddWorkouts(List<Swimmer> swimmers)
        {
            Swimmers.AddRange(swimmers);
        }

        public int CompareTo(Workout workout)
        {
            if (workout == null) return 1;
            else
                return this.Schedule.CompareTo(workout.Schedule);
        }

        public override string ToString()
        {
            return string.Format("{0} sessie [{1}'] in {2} op {3}", Type, Duration, SwimmingPool, Schedule);


        }
    }
}
