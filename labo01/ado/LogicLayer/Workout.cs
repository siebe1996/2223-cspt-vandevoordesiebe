using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Workout : IComparable<Workout>
    {
        public Coach Coach { get; }
        public int Duration { get; }
        public int Id { get; }
        public DateTime Schedule { get; }
        public SwimmingPool SwimmingPool { get; }
        public WorkoutType Type { get; }

        public Workout(WorkoutModel workout)
        {
            //Coach = new Coach(workout.Coach); cirkel code
            Duration = workout.Duration;
            Id = workout.Id;
            Schedule = workout.Schedule;
            SwimmingPool = new SwimmingPool(workout.SwimmingPool);
            WorkoutType Type = (WorkoutType)workout.Type;
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

        public int CompareTo(Workout workout)
        {
            if (workout == null) return 1;
            else
                return this.Schedule.CompareTo(workout.Schedule);
        }

        public override string ToString()
        {
            return string.Format("{0} sessie [{1}'] in {2} op {3}", Type, Duration, SwimmingPool.Name, Schedule);


        }
    }
}
