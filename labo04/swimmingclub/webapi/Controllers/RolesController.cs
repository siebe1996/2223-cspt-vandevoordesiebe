﻿using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Roles;

namespace webapi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        [Consumes("application/json")]
        public async Task<ActionResult<GetRoleModel>> GetRoles()
        {
            var models = await _roleRepository.GetRoles();
            return models == null ? NotFound() : Ok(models);
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<GetRoleModel>> GetRole(Guid Id)
        {
            var model = await _roleRepository.GetRole(Id);
            return model == null ? NotFound() : Ok(model);
            
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<GetRoleModel>> PostRole(PostRoleModel postRoleModel)
        {
            GetRoleModel getRoleModel = await _roleRepository.PostRole(postRoleModel);
            return CreatedAtAction("GetRole", new { id = getRoleModel.Id }, getRoleModel);
        }
    }
}
