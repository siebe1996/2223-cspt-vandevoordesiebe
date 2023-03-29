using models.Attendances;
using models.MemberRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.interfaces
{
    public interface IMemberRoleRepository
    {
        Task<List<GetMemberRoleModel>> GetMemberRoles();
        Task<List<GetMemberRoleModel>> GetMemberRolesByMemberId(Guid id);
        Task<List<GetMemberRoleModel>> GetMemberRolesByRoleId(Guid id);
        Task<GetMemberRoleModel> GetMemberRoleByIds(Guid memberId, Guid roleId);
        Task<GetMemberRoleModel> AddUserToRole(PostMemberRoleModel postMemberRoleModel);
    }
}
