using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
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
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public DateTime Schedule { get; set; }
        public virtual SwimmingPool SwimmingPool { get; set; }
        public WorkoutType Type { get; set; }

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

        public Workout(Coach coach, int duration, DateTime schedule, SwimmingPool swimmingPool, WorkoutType type)
        {
            Coach = coach;
            Duration = duration;
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
            return string.Format("{0} sessie [{1}'] in {2} op {3}", Type, Duration, SwimmingPool, Schedule);


        }
    }
}
