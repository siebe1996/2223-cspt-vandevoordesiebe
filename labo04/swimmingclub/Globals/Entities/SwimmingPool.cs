using Globals.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Entities
{
    public class SwimmingPool
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(@"^(?i)[a-z ,.'-]+$")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int ZipCode { get; set; }

        [Required]
        [EnumDataType(typeof(LaneLength))]
        public LaneLength LaneLength { get; set; }

        //navigation props
        public virtual ICollection<Race> Races { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
