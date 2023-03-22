using Globals.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.SwimmingPools
{
    public class BaseSwimmingPoolModel
    {
        [Required]
        [RegularExpression(@"^(?i)[a-z ,.'-]+$")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Street { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int ZipCode { get; set; }

        [Required]
        [EnumDataType(typeof(LaneLength))]
        public LaneLength LaneLength { get; set; }
    }
}
