using Globals.Enums;
using models.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Coaches
{
    public class BaseCoachModel : BaseMemberModel
    {
        [Required]
        [EnumDataType(typeof(Level))]
        public Level Level { get; set; }
    }
}
