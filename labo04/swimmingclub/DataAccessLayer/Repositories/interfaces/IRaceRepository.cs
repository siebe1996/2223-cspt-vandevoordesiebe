using models.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.interfaces
{
    public interface IRaceRepository
    {
        Task<List<GetRaceModel>> GetRaces();
        Task<List<GetRaceResultModel>> GetRacesResults();
        Task<GetRaceModel> GetRace(Guid id);
        Task<GetRaceModel> PostRace(PostRaceModel postRaceModel);
    }
}
