using Globals.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Entities
{
    [Table("Coaches")]
    public class Coach : Member
    {
        [Required]
        [EnumDataType(typeof(Level))]
        public Level Level { get; set; }

        //navigation props
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
