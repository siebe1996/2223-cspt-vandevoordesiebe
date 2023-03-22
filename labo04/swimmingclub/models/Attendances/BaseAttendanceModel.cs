using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Attendances
{
    public class BaseAttendanceModel
    {
        [Required]
        public Guid SwimmerId { get; set; }

        [Required]
        public Guid WorkoutId { get; set; }

        [Required]
        public Boolean Present { get; set; }

        [StringLength(50)]
        public string? Remark { get; set; }
    }
}
