using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Coaches;
using models.Members;

namespace webapi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        //The refresh token is being sent in an HTTP only cookie and header
        private void SetTokenCookie(string token)
        {
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(2), //TOKEN REFRESH
                IsEssential = true,
            };

            Response.Cookies.Append("Swimmingclub.RefreshToken", token, cookieOptions);
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ActionResult<PostAuthenticateResponseModel>> Authenticate(PostAuthenticateRequestModel postAuthenticateRequestModel)
        {
            try
            {
                PostAuthenticateResponseModel postAuthenticateResponseModel = await _memberRepository.Authenticate(postAuthenticateRequestModel, IpAddress());
                SetTokenCookie(postAuthenticateResponseModel.RefreshToken);
                return Ok(postAuthenticateResponseModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Renew-token")]
        public async Task<ActionResult<PostAuthenticateResponseModel>> RenewToken()
        {
            try
            {
                string refreshToken = Request.Cookies["Swimmingclub.RefreshToken"];
                PostAuthenticateResponseModel postAuthenticateResponseModel = await _memberRepository.RenewToken(refreshToken, IpAddress());
                SetTokenCookie(postAuthenticateResponseModel.RefreshToken);
                return Ok(postAuthenticateResponseModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Deactivate-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeactivateToken(PostDeactivateTokenRequestModel postDeactivateTokenRequestModel)
        {
            try
            {
                // Accept token from request body or cookie
                string token = postDeactivateTokenRequestModel.Token ?? Request.Cookies["Swimmingclub.RefreshToken"];
                if (string.IsNullOrEmpty(token))
                {
                    throw new Exception("refresh token is required");
                }
                await _memberRepository.DeactivateToken(token, IpAddress());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
