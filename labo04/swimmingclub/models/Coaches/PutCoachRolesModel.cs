using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Coaches
{
    public class PutCoachRolesModel
    {
        [Required]
        public List<string> Roles { get; set; }
    }
}
