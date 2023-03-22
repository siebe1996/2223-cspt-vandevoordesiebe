using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.SwimmingPools
{
    public class GetSwimmingPoolModel : BaseSwimmingPoolModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
