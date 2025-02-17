﻿using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SwimmingClubContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _member;
        private readonly RoleManager<Role> _roleManager;

        public RoleRepository(SwimmingClubContext context, IHttpContextAccessor httpContextAccessor, RoleManager<Role> roleManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _member = _httpContextAccessor.HttpContext.User;
            _roleManager = roleManager;
        }

        public async Task<List<GetRoleModel>> GetRoles()
        {
            List<GetRoleModel> roles = await _context.Roles.Select(x => new GetRoleModel
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
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
                Name = x.Name
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            return role;
        }

        public async Task<GetRoleModel> PostRole(PostRoleModel postRoleModel)
        {
            Role role = new Role
            {
                Name = postRoleModel.Name,
                Description = postRoleModel.Description,
            };

            IdentityResult result = await _roleManager.CreateAsync(role);

            GetRoleModel roleModel = new GetRoleModel
            {
                Id = role.Id,
                Name = postRoleModel.Name,
                Description = role.Description,
            };

            return roleModel;
        }
    }
}
