using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Entities
{
    //[Table("Swimmers")]
    public class Swimmer : Member
    {
        [Required]
        [Range(0, 10)]
        public int FinaPoints { get; set; }

        //navigation props
        public virtual ICollection<Attendance> Attendences { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
