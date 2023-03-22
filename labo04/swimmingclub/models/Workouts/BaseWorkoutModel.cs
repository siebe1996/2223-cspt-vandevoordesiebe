using Globals.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Workouts
{
    public class BaseWorkoutModel
    {
        [Required]
        public Guid SwimmingPoolId { get; set; }

        [Required]
        public Guid CoachId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Schedule { get; set; }

        [Required]
        [EnumDataType(typeof(WorkoutType))]
        public WorkoutType WorkoutType { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
