using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.EntityFrameworkCore;
using models.Results;
using models.SwimmingPools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SwimmingPoolRepository : ISwimmingPoolRepository
    {
        private readonly SwimmingClubContext _context;

        public SwimmingPoolRepository(SwimmingClubContext context)
        {
            _context = context;
        }

        public async Task<List<GetSwimmingPoolModel>> GetSwimmingPools()
        {
            List<GetSwimmingPoolModel> swimmingPools = await _context.SwimmingPools.Select(x => new GetSwimmingPoolModel
            {
                Id = x.Id,
                Name = x.Name,
                Street = x.Street,
                City = x.City,
                ZipCode = x.ZipCode,
                LaneLength = x.LaneLength,
            }).AsNoTracking()
            .ToListAsync();

            return swimmingPools;
        }

        public async Task<GetSwimmingPoolModel> GetSwimmingPool(Guid id)
        {
            GetSwimmingPoolModel swimmingPool = await _context.SwimmingPools.Select(x => new GetSwimmingPoolModel
            {
                Id = x.Id,
                Name = x.Name,
                Street = x.Street,
                City = x.City,
                ZipCode = x.ZipCode,
                LaneLength = x.LaneLength,
            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            return swimmingPool;
        }

        public async Task<GetSwimmingPoolModel> PostSwimmingPool(PostSwimmingPoolModel postSwimmingPoolModel)
        {
            SwimmingPool swimmingPool = new SwimmingPool
            {
                Name = postSwimmingPoolModel.Name,
                Street = postSwimmingPoolModel.Street,
                City = postSwimmingPoolModel.City,
                ZipCode = postSwimmingPoolModel.ZipCode,
                LaneLength = postSwimmingPoolModel.LaneLength,
            };

            _context.SwimmingPools.Add(swimmingPool);
            await _context.SaveChangesAsync();

            GetSwimmingPoolModel getSwimmingPoolModel = new GetSwimmingPoolModel
            {
                Id = swimmingPool.Id,
                Name = swimmingPool.Name,
                Street = swimmingPool.Street,
                City = swimmingPool.City,
                ZipCode = swimmingPool.ZipCode,
                LaneLength = swimmingPool.LaneLength,
            };

            return getSwimmingPoolModel;
        }
    }
}
