using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Workouts
{
    public class GetWorkoutAbsenceModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Schedulde { get; set; }

        [Required]
        [StringLength(101, MinimumLength = 4)]
        public string CoachFullName { get; set; }

        [Required]
        public List<string> SwimmerNames { get; set; }
    }
}
