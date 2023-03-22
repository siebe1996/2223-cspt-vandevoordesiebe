using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using models.Coaches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private readonly SwimmingClubContext _context;
        private readonly UserManager<Member> _userManager;

        public CoachRepository(SwimmingClubContext context, UserManager<Member> userManager)
        {
            _context = context;
            _userManager = userManager;
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
    }
}
