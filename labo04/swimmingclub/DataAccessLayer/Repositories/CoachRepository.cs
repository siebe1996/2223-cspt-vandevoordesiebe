using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using models.Coaches;
using models.MemberRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private readonly SwimmingClubContext _context;
        private readonly UserManager<Member> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _member;
        private readonly RoleManager<Role> _roleManager;

        public CoachRepository(SwimmingClubContext context, IHttpContextAccessor httpContextAccessor, UserManager<Member> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _member = _httpContextAccessor.HttpContext.User;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<GetCoachModel>> GetCoaches()
        {
            List<GetCoachModel> coaches = await _context.Coaches.Select(x => new GetCoachModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                Level = x.Level,
                Email = x.Email,
                UserName = x.UserName
            }).AsNoTracking()
            .ToListAsync();

            return coaches;
        }

        public async Task<GetCoachModel> GetCoach (Guid id)
        {
            GetCoachModel coach = await _context.Coaches.Select(x => new GetCoachModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                Level = x.Level,
                Email = x.Email,
                UserName = x.UserName
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            return coach;
        }

        public async Task<GetCoachModel> PostCoach (PostCoachModel postCoachModel)
        {
            Coach coach = new Coach
            {
                FirstName = postCoachModel.FirstName,
                LastName = postCoachModel.LastName,
                DateOfBirth = postCoachModel.DateOfBirth,
                Gender = postCoachModel.Gender,
                Level = postCoachModel.Level,
                Email = postCoachModel.Email,
                UserName = postCoachModel.UserName
            };

            IdentityResult result = await _userManager.CreateAsync(coach, postCoachModel.Password);

            GetCoachModel coachmodel = new GetCoachModel
            {
                Id = coach.Id,
                FirstName = coach.FirstName,
                LastName = coach.LastName,
                DateOfBirth = coach.DateOfBirth,
                Gender = coach.Gender,
                Level = coach.Level,
                Email = coach.Email,
                UserName = coach.UserName
            };

            return coachmodel;
        }

        public async Task<GetCoachRolesModel> AddUserToRole(Guid id, PutCoachRolesModel putCoachRolesModel)
        {
            var member = await _context.Coaches.FirstOrDefaultAsync(x => x.Id == id);
            var roles = await _userManager.GetRolesAsync(member);
            await _userManager.RemoveFromRolesAsync(member, roles);

            if (member != null)
            {
                foreach(string roleName in putCoachRolesModel.Roles)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);
                    if (role != null)
                    {
                        IdentityResult result = _userManager.AddToRoleAsync(member, role.Name).Result;
                    }
                    else
                    {
                        throw new Exception("role not found");
                    }
                }
                GetCoachRolesModel getCoachRolesModel = await _context.Coaches.Where(x => x.Id == id).Select(x => new GetCoachRolesModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Roles = x.MemberRoles.Select(x => x.Role.Name).ToList(),
                }).AsNoTracking().FirstOrDefaultAsync();

                return getCoachRolesModel;
            }
            else
            {
                throw new Exception("member not found");
            }
        }
    }
}
