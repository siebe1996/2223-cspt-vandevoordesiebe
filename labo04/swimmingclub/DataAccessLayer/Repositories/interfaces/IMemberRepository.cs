using models.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.interfaces
{
    public interface IMemberRepository
    {
        Task<PostAuthenticateResponseModel> Authenticate(PostAuthenticateRequestModel postAuthenticateRequestModel, string ipAddress);
        Task<PostAuthenticateResponseModel> RenewToken(string token, string ipAddress);
        Task DeactivateToken(string token, string ipAddress);
    }
}
