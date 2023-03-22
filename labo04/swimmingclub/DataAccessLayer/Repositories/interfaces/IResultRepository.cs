using models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.interfaces
{
    public interface IResultRepository
    {
        Task<List<GetResultModel>> GetResults();
        Task<List<GetResultModel>> GetResultsBySwimmerId(Guid id);
        Task<List<GetResultModel>> GetResultsByRaceId(Guid id);
        Task<GetResultModel> GetResultByIds(Guid swimmerId, Guid raceId);
        Task<GetResultModel> PostResult(PostResultModel postResultModel);
    }
}
