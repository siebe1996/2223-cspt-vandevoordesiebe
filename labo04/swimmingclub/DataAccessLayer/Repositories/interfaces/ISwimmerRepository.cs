using models.Swimmers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.interfaces
{
    public interface ISwimmerRepository
    {
        Task<List<GetSwimmerModel>> GetSwimmers();
        Task<GetSwimmerModel> GetSwimmer(Guid id);
        Task<GetSwimmerModel> PostSwimmer(PostSwimmerModel postSwimmerModel);
        Task<GetSwimmerRolesModel> AddUserToRole(Guid id, PutSwimmerRolesModel putSwimmerRolesModel);
    }
}
