using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SwimmingClubContext _context;
        private readonly RoleManager<Role> _roleManager;

        public RoleRepository(SwimmingClubContext context, RoleManager<Role> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<List<GetRoleModel>> GetRoles()
        {
            List<GetRoleModel> roles = await _context.Roles.Select(x => new GetRoleModel
            {
                Id = x.Id,
                Description = x.Description,
            }).AsNoTracking()
            .ToListAsync();

            return roles;
        }

        public async Task<GetRoleModel> GetRole(Guid id)
        {
            GetRoleModel role = await _context.Roles.Select(x => new GetRoleModel
            {
                Id = x.Id,
                Description = x.Description,
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            return role;
        }

        public async Task<GetRoleModel> PostRole(PostRoleModel postRoleModel)
        {
            Role role = new Role
            {
                Description = postRoleModel.Description,
            };

            IdentityResult result = await _roleManager.CreateAsync(role);

            GetRoleModel roleModel = new GetRoleModel
            {
                Id = role.Id,
                Description = role.Description,
            };

            return roleModel;
        }
    }
}
