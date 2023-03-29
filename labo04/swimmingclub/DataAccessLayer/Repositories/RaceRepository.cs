using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using models.Races;
using models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        private readonly SwimmingClubContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _member;

        public RaceRepository(SwimmingClubContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _member = _httpContextAccessor.HttpContext.User;
        }

        public async Task<List<GetRaceModel>> GetRaces()
        {
            List<GetRaceModel> races = await _context.Races.Select(x => new GetRaceModel
            {
                Id = x.Id,
                SwimmingPoolId = x.SwimmingPoolId,
                Schedule = x.Schedule,
                Stroke = x.Stroke,
                Distance = x.Distance,
                AgeCategory = x.AgeCategory,
                Gender = x.Gender,
            }).AsNoTracking()
            .ToListAsync();

            return races;
        }

        public async Task<List<GetRaceResultModel>> GetRacesResults()
        {
            List<GetRaceResultModel> races = await _context.Races.Where(x => x.Schedule < DateTime.Now)
                .Select(x => new GetRaceResultModel
            {
                Id = x.Id,
                SwimmingPoolName = x.SwimmingPool.Name,
                Schedule = x.Schedule,
                Stroke = x.Stroke,
                Distance = x.Distance,
                AgeCategory = x.AgeCategory,
                Gender = x.Gender,
                GetResultSwimmerModels = x.Results.Select(x => new GetResultSwimmerModel
                {
                    SwimmerFullName = $"{x.Swimmer.FirstName} {x.Swimmer.LastName}",
                    RaceResult = x.RaceResult,
                }).ToList(),
            }).AsNoTracking()
            .ToListAsync();

            return races;
        }

        public async Task<GetRaceModel> GetRace(Guid id)
        {
            GetRaceModel race = await _context.Races.Select(x => new GetRaceModel
            {
                Id = x.Id,
                SwimmingPoolId = x.SwimmingPoolId,
                Schedule = x.Schedule,
                Stroke = x.Stroke,
                Distance = x.Distance,
                AgeCategory = x.AgeCategory,
                Gender = x.Gender,
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            return race;
        }

        public async Task<GetRaceModel> PostRace(PostRaceModel postRaceModel)
        {
            Race race = new Race
            {
                SwimmingPoolId = postRaceModel.SwimmingPoolId,
                Schedule = postRaceModel.Schedule,
                Stroke = postRaceModel.Stroke,
                Distance = postRaceModel.Distance,
                AgeCategory = postRaceModel.AgeCategory,
                Gender = postRaceModel.Gender,
            };

            _context.Races.Add(race);
            await _context.SaveChangesAsync();

            GetRaceModel getRaceModel = new GetRaceModel
            {
                Id = race.Id,
                SwimmingPoolId = race.SwimmingPoolId,
                Schedule = race.Schedule,
                Stroke = race.Stroke,
                Distance = race.Distance,
                AgeCategory = race.AgeCategory,
                Gender = race.Gender,
            };

            return getRaceModel;
        }
    }
}
