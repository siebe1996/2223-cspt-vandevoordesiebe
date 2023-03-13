using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Entities
{
    public class Result
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

        //navigation props
        public virtual Swimmer Swimmer { get; set; }
        public virtual Race Race { get; set; }
    }
}
