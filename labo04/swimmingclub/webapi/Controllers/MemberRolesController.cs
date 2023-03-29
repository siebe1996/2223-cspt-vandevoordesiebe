using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.MemberRoles;

namespace webapi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class MemberRolesController : ControllerBase
    {
        private readonly IMemberRoleRepository _memberRoleRepository;

        public MemberRolesController(IMemberRoleRepository memberRoleRepository)
        {
            _memberRoleRepository = memberRoleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<GetMemberRoleModel>> GetMemberRoles()
        {
            List<GetMemberRoleModel> results = await _memberRoleRepository.GetMemberRoles();
            return results == null ? NotFound() : Ok(results);
        }

        [HttpGet("Search")]
        public async Task<ActionResult<GetMemberRoleModel>> GetMemberRoleByIds(Guid memberId, Guid roleId)
        {
            GetMemberRoleModel result = await _memberRoleRepository.GetMemberRoleByIds(memberId, roleId);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GetMemberRoleModel>> AddUserToRole(PostMemberRoleModel postMemberRoleModel)
        {
            GetMemberRoleModel result = await _memberRoleRepository.AddUserToRole(postMemberRoleModel);
            return CreatedAtAction("GetMemberRoleByIds", new { memberId = result.MemberId, roleId = result.RoleId }, result);
        }
    }
}
