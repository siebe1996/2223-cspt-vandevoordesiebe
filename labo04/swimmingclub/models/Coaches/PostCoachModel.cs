using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Coaches
{
    public class PostCoachModel : BaseCoachModel
    {
        [Required]
        public string Password { get; set; }
    }
}
