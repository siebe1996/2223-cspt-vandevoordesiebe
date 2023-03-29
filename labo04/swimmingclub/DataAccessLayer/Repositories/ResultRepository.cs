using Globals.Helpers;
using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly SwimmingClubContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _member;

        public ResultRepository(SwimmingClubContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _member = _httpContextAccessor.HttpContext.User;
        }

        public async Task<List<GetResultModel>> GetResults()
        {
            if (_member.Claims.Where(x => x.Type.Contains("role")).Count() >= 1 &&
                _member.IsInRole("Coach"))
            {
                List<GetResultModel> results = await _context.Results.Select(x => new GetResultModel
                {
                    SwimmerId = x.SwimmerId,
                    RaceId = x.RaceId,
                    CurrentPersonalBest = x.CurrentPersonalBest,
                    RaceResult = x.RaceResult,
                }).AsNoTracking()
            .ToListAsync();

                return results;
            }
            else
            {
                throw new ForbiddenException("Forbidden to access this page");
            }
        }

        public async Task<List<GetResultModel>> GetResultsBySwimmerId(Guid id)
        {
            List<GetResultModel> results = await _context.Results.Where(x => x.SwimmerId == id)
            .Select(x => new GetResultModel
            {
                SwimmerId = x.SwimmerId,
                RaceId = x.RaceId,
                CurrentPersonalBest = x.CurrentPersonalBest,
                RaceResult = x.RaceResult,
            }).AsNoTracking()
            .ToListAsync();

            return results;
        }

        public async Task<List<GetResultModel>> GetResultsByRaceId(Guid id)
        {
            List<GetResultModel> results = await _context.Results.Where(x => x.RaceId == id)
            .Select(x => new GetResultModel
            {
                SwimmerId = x.SwimmerId,
                RaceId = x.RaceId,
                CurrentPersonalBest = x.CurrentPersonalBest,
                RaceResult = x.RaceResult,
            }).AsNoTracking()
            .ToListAsync();

            return results;
        }

        public async Task<GetResultModel> GetResultByIds(Guid swimmerId, Guid raceId)
        {
            GetResultModel result = await _context.Results.Select(x => new GetResultModel
            {
                SwimmerId = x.SwimmerId,
                RaceId = x.RaceId,
                CurrentPersonalBest = x.CurrentPersonalBest,
                RaceResult = x.RaceResult,
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.RaceId == raceId && x.SwimmerId == swimmerId);

            return result;
        }

        public async Task<GetResultModel> PostResult(PostResultModel postResultModel)
        {
            Result result = new Result
            {
                SwimmerId = postResultModel.SwimmerId,
                RaceId = postResultModel.RaceId,
                CurrentPersonalBest = postResultModel.CurrentPersonalBest,
                RaceResult = postResultModel.RaceResult,
            };

            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            GetResultModel getResultModel = new GetResultModel
            {
                SwimmerId = result.SwimmerId,
                RaceId = result.RaceId,
                CurrentPersonalBest = result.CurrentPersonalBest,
                RaceResult = result.RaceResult,
            };

            return getResultModel;
        }
    }
}
