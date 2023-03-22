using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Results
{
    public class BaseResultModel
    {
        [Required]
        public Guid SwimmerId { get; set; }

        [Required]
        public Guid RaceId { get; set; }

        [Required]
        [StringLength(8)]
        public string CurrentPersonalBest { get; set; }

        [Required]
        [StringLength(8)]
        public string RaceResult { get; set; }
    }
}
