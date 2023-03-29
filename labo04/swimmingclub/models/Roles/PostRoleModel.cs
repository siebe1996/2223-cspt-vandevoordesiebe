using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Roles
{
    public class PostRoleModel : BaseRoleModel
    {
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }
}
