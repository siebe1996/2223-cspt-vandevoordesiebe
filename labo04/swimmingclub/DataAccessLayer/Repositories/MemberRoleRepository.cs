using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using models.MemberRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class MemberRoleRepository : IMemberRoleRepository
    {
        private readonly SwimmingClubContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _member;
        private readonly UserManager<Member> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public MemberRoleRepository(SwimmingClubContext context, IHttpContextAccessor httpContextAccessor, UserManager<Member> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _member = _httpContextAccessor.HttpContext.User;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<GetMemberRoleModel>> GetMemberRoles()
        {
            List<GetMemberRoleModel> memberRoles = await _context.MemberRoles.Select(x => new GetMemberRoleModel
            {
                MemberId = x.UserId,
                RoleId = x.RoleId,
            }).AsNoTracking()
            .ToListAsync();

            return memberRoles;
        }

        public async Task<List<GetMemberRoleModel>> GetMemberRolesByMemberId(Guid id)
        {
            List<GetMemberRoleModel> memberRoles = await _context.MemberRoles.Select(x => new GetMemberRoleModel
            {
                MemberId = x.UserId,
                RoleId = x.RoleId,
            }).AsNoTracking()
            .Where(x => x.MemberId == id)
            .ToListAsync();

            return memberRoles;
        }


        public async Task<List<GetMemberRoleModel>> GetMemberRolesByRoleId(Guid id)
        {
            List<GetMemberRoleModel> memberRoles = await _context.MemberRoles.Select(x => new GetMemberRoleModel
            {
                MemberId = x.UserId,
                RoleId = x.RoleId,
            }).AsNoTracking()
            .Where(x => x.RoleId == id)
            .ToListAsync();

            return memberRoles;
        }

        public async Task<GetMemberRoleModel> GetMemberRoleByIds(Guid memberId, Guid roleId)
        {
            GetMemberRoleModel memberRole = await _context.MemberRoles.Select(x => new GetMemberRoleModel
            {
                MemberId = x.UserId,
                RoleId = x.RoleId,
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.MemberId == memberId && x.RoleId == roleId);

            return memberRole;
        }


        public async Task<GetMemberRoleModel> AddUserToRole (PostMemberRoleModel postMemberRoleModel)
        {
            var member = await _context.Members.FirstOrDefaultAsync(x => x.Id == postMemberRoleModel.MemberId);
            var memberRoleModel = await this.GetMemberRoleByIds(postMemberRoleModel.MemberId, postMemberRoleModel.RoleId);
            if (member != null)
            {
                if (memberRoleModel == null)
                {
                    String? roleName = await _context.Roles.Where(x => x.Id == postMemberRoleModel.RoleId).Select(x => x.Name).FirstOrDefaultAsync();
                    if (roleName != null)
                    {
                        IdentityResult result = _userManager.AddToRoleAsync(member, roleName).Result;
                        return new GetMemberRoleModel { MemberId = postMemberRoleModel.MemberId, RoleId = postMemberRoleModel.RoleId };
                    }
                    else
                    {
                        throw new Exception("role not found");
                    }
                }
                else
                {
                    throw new Exception("member has role already");
                }
            }
            else
            {
                throw new Exception("member not found");
            }
        }
    }
}
