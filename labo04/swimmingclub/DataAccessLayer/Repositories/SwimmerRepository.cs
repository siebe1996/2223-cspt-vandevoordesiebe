using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using models.Swimmers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SwimmerRepository : ISwimmerRepository
    {
        private readonly SwimmingClubContext _context;
        private readonly UserManager<Member> _userManager;

        public SwimmerRepository(SwimmingClubContext context, UserManager<Member> userManager)
        {
            _context = context;
            _userManager = userManager;
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
    }
}
