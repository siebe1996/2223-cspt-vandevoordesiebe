using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Swimmers
{
    public class PostSwimmerModel : BaseSwimmerModel
    {
        [Required]
        public string Password { get; set; }
    }
}
