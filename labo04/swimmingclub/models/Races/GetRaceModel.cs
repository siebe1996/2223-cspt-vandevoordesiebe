using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Races
{
    public class GetRaceModel : BaseRaceModel
    {
        [Required]
        public Guid SwimmingPoolId { get; set; }

        [Required]
        public Guid Id { get; set; }
    }
}
