using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.MemberRoles
{
    public class BaseMemberRoleModel
    {
        [Required]
        public Guid MemberId { get; set; }

        [Required]
        public Guid RoleId { get; set; }
    }
}
