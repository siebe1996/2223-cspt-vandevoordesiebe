using models.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Races
{
    public class GetRaceResultModel : BaseRaceModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(@"^(?i)[a-z ,.'-]+$")]
        public string SwimmingPoolName { get; set; }

        [Required]
        public List<GetResultSwimmerModel> GetResultSwimmerModels { get; set; }

    }
}
