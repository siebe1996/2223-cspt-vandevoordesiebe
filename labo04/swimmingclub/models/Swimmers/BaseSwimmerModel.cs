using models.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Swimmers
{
    public class BaseSwimmerModel : BaseMemberModel
    {
        [Required]
        [Range(0, 10)]
        public int FinaPoints { get; set; }
    }
}
