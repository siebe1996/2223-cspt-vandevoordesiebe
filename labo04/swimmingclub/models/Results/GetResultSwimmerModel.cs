using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Results
{
    public class GetResultSwimmerModel
    {
        [Required]
        [StringLength(101, MinimumLength = 4)]
        public string SwimmerFullName { get; set; }

        [Required]
        [StringLength(8)]
        public string RaceResult { get; set; }
    }
}
