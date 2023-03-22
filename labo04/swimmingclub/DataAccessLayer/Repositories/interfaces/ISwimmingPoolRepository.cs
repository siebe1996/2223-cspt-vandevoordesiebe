using models.SwimmingPools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.interfaces
{
    public interface ISwimmingPoolRepository
    {
        Task<List<GetSwimmingPoolModel>> GetSwimmingPools();
        Task<GetSwimmingPoolModel> GetSwimmingPool(Guid id);
        Task<GetSwimmingPoolModel> PostSwimmingPool(PostSwimmingPoolModel postSwimmingPoolModel);
    }
}
