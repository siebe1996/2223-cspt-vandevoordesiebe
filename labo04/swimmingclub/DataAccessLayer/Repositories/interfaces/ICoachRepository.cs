using models.Coaches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.interfaces
{
    public interface ICoachRepository
    {
        Task<List<GetCoachModel>> GetCoaches();
        Task<GetCoachModel> GetCoach(Guid id);
        Task<GetCoachModel> PostCoach(PostCoachModel postCoachModel);
    }
}
