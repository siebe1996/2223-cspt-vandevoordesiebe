using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Coaches
{
    public class GetCoachModel : BaseCoachModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public List<string> roles { get; set; }
    }
}
