using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Globals.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using models.Results;
using models.Swimmers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SwimmerRepository : ISwimmerRepository
    {
        private readonly SwimmingClubContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _member;
        private readonly UserManager<Member> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public SwimmerRepository(SwimmingClubContext context, IHttpContextAccessor httpContextAccessor, UserManager<Member> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _member = _httpContextAccessor.HttpContext.User;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<GetSwimmerModel>> GetSwimmers()
        {
            List<GetSwimmerModel> swimmers = await _context.Swimmers.Select(x => new GetSwimmerModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                FinaPoints = x.FinaPoints,
                Email = x.Email,
                UserName = x.UserName
            }).AsNoTracking()
            .ToListAsync();

            return swimmers;
        }

        public async Task<GetSwimmerModel> GetSwimmer(Guid id)
        {
            GetSwimmerModel swimmer = await _context.Swimmers.Select(x => new GetSwimmerModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                FinaPoints = x.FinaPoints,
                Email = x.Email,
                UserName = x.UserName
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            return swimmer;
        }

        public async Task<GetSwimmerResultsModel> GetSwimmerResults(Guid id)
        {
            if (_member.Claims.Where(x => x.Type.Contains("role")).Count() == 1 &&
                _member.IsInRole("swimmer") &&
                _member.Identity.Name != id.ToString())
            {
                throw new ForbiddenException("Forbidden to get these results");
            }
            else
            {
                GetSwimmerResultsModel getSwimmerResultsModel = await _context.Swimmers.Select(x => new GetSwimmerResultsModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Results = x.Results.Select(x => new GetResultModel
                    {
                        SwimmerId = x.SwimmerId,
                        RaceId = x.RaceId,
                        CurrentPersonalBest = x.CurrentPersonalBest,
                        RaceResult = x.RaceResult,
                    }).ToList()
                }).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                return getSwimmerResultsModel;
            }
        }

        public async Task<GetSwimmerModel> PostSwimmer(PostSwimmerModel postSwimmerModel)
        {
            Swimmer swimmer = new Swimmer
            {
                FirstName = postSwimmerModel.FirstName,
                LastName = postSwimmerModel.LastName,
                DateOfBirth = postSwimmerModel.DateOfBirth,
                Gender = postSwimmerModel.Gender,
                FinaPoints = postSwimmerModel.FinaPoints,
                Email = postSwimmerModel.Email,
                UserName = postSwimmerModel.UserName,
            };  

            IdentityResult result = await _userManager.CreateAsync(swimmer, postSwimmerModel.Password);

            GetSwimmerModel swimmerModel = new GetSwimmerModel
            {
                Id = swimmer.Id,
                FirstName = swimmer.FirstName,
                LastName = swimmer.LastName,
                DateOfBirth = swimmer.DateOfBirth,
                Gender = swimmer.Gender,
                FinaPoints = swimmer.FinaPoints,
                Email = swimmer.Email,
                UserName = swimmer.UserName,
            };

            return swimmerModel;
        }

        public async Task<GetSwimmerRolesModel> AddUserToRole(Guid id, PutSwimmerRolesModel putSwimmerRolesModel)
        {
            var member = await _context.Swimmers.FirstOrDefaultAsync(x => x.Id == id);
            var roles = await _userManager.GetRolesAsync(member);
            await _userManager.RemoveFromRolesAsync(member, roles);

            if (member != null)
            {
                foreach (string roleName in putSwimmerRolesModel.Roles)
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
                GetSwimmerRolesModel getSwimmerRolesModel = await _context.Swimmers.Where(x => x.Id == id).Select(x => new GetSwimmerRolesModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Roles = x.MemberRoles.Select(x => x.Role.Name).ToList(),
                }).AsNoTracking().FirstOrDefaultAsync();

                return getSwimmerRolesModel;
            }
            else
            {
                throw new Exception("member not found");
            }
        }
    }
}
