using Globals.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Races
{
    public class BaseRaceModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Schedule { get; set; }

        [Required]
        [EnumDataType(typeof(Stroke))]
        public Stroke Stroke { get; set; }

        [Required]
        public int Distance { get; set; }

        [Required]
        [EnumDataType(typeof(AgeCategory))]
        public AgeCategory AgeCategory { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
    }
}
