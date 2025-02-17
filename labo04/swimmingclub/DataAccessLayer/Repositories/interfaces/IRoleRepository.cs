﻿using models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.interfaces
{
    public interface IRoleRepository
    {
        Task<List<GetRoleModel>> GetRoles();
        Task<GetRoleModel> GetRole(Guid id);
        Task<GetRoleModel> PostRole(PostRoleModel postRoleModel);
    }
}
