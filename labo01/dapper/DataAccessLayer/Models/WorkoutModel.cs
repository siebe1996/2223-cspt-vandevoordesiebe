using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class WorkoutModel : IComparable<WorkoutModel>
    {
        public CoachModel Coach { get; set; }
        public int Duration { get; }
        public int Id { get; }
        public DateTime Schedule { get; }
        public SwimmingPoolModel SwimmingPool { get; set; }
        public WorkoutTypeModel Type { get; }

        public WorkoutModel(int id,  int duration, DateTime schedule, WorkoutTypeModel type)
        {
            Duration = duration;
            Id = id;
            Schedule = schedule;
            Type = type;
        }

        public WorkoutModel(int id, CoachModel coach, int duration, DateTime schedule, SwimmingPoolModel swimmingPool, WorkoutTypeModel type)
        {
            Coach = coach;
            Duration = duration;
            Id = id;
            Schedule = schedule;
            SwimmingPool = swimmingPool;
            Type = type;
        }

        public int CompareTo(WorkoutModel workout)
        {
            if (workout == null) return 1;
            else
                return this.Schedule.CompareTo(workout.Schedule);
        }

        public override string ToString()
        {
            return string.Format("{0} sessie [{1}'] in {2} op {3}}", Type, Duration, SwimmingPool, Schedule);
        }
    }
}
