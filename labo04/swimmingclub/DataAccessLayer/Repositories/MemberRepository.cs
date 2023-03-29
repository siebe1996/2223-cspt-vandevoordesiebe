using Globals.Helpers;
using DataAccessLayer.Repositories.interfaces;
using Globals.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using models.Members;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Castle.Core.Configuration;
using Globals.Interfaces;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly SignInManager<Member> _signInManager;
        private readonly UserManager<Member> _userManager;
        private readonly AppSettings _appSettings;
        private readonly SwimmingClubContext _context;

        public MemberRepository(SwimmingClubContext swimmingClubContext, SignInManager<Member> signInManager, UserManager<Member> userManager, IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            //_appSettings = new AppSettings();
            _context = swimmingClubContext;
        }

        public async Task<string> GenerateJwtToken(Member member)
        {
            var roleNames = await _userManager.GetRolesAsync(member).ConfigureAwait(false);

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, member.Id.ToString()),
                new Claim("FirstName", member.FirstName),
                new Claim("LastName", member.LastName),
                new Claim("UserName", member.UserName)
            };

            foreach (string roleName in roleNames)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));
            }

            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Issuer = "Swimmingclub Web API",
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddSeconds(30), //TOKEN JWT
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            byte[] randomBytes = RandomNumberGenerator.GetBytes(64);

            //The refresh token expires time must be the same as the refresh token cookie expires time set in the SetTokenCookie method in MembersController
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddMinutes(2), //TOKEN REFRESH
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress,
            };
        }

        public async Task<PostAuthenticateResponseModel> Authenticate(PostAuthenticateRequestModel postAuthenticateRequestModel, string ipAddress)
        {
            Member member = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == postAuthenticateRequestModel.UserName);

            if (member == null)
            {
                throw new Exception("invalid e-mail");
            }

            //Verify password when user was found by UserName
            SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(member, postAuthenticateRequestModel.Password, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                throw new Exception("invalid password");
            }

            //Authentication was successfull so generate JWT and refresh tokens
            string jwtToken = await GenerateJwtToken(member);
            RefreshToken refreshToken = GenerateRefreshToken(ipAddress);

            var test = member;
            //Save refresh token
            member.RefreshTokens.Add(refreshToken);

            await _userManager.UpdateAsync(member);

            return new PostAuthenticateResponseModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                UserName = member.UserName,
                JwtToken = jwtToken,
                RefreshToken = refreshToken.Token,
                Roles = await _userManager.GetRolesAsync(member)
            };
        }

        public async Task<PostAuthenticateResponseModel> RenewToken(string token, string ipAddress)
        {
            Member member = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshTokens.Any(t => t.Token == token));

            if (member == null)
            {
                throw new Exception("no user was found with this token");
            }

            RefreshToken refreshToken = member.RefreshTokens.Single(x => x.Token == token);

            //Refresh token is no longer active
            if (!refreshToken.IsActive)
            {
                throw new Exception("refresh token is expired");
            }

            //Replace old refresh token with a new one
            RefreshToken newRefreshToken = GenerateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;

            //Generate new jwt
            string jwtToken = await GenerateJwtToken(member);

            member.RefreshTokens.Add(refreshToken);

            await _userManager.UpdateAsync(member);

            return new PostAuthenticateResponseModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                UserName = member.UserName,
                JwtToken = jwtToken,
                RefreshToken = newRefreshToken.Token,
                Roles = await _userManager.GetRolesAsync(member)
            };
        }

        public async Task DeactivateToken(string token, string ipAddress)
        {
            Member member = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshTokens.Any(x => x.Token == token));

            if (member == null)
            {
                throw new Exception("no user was found with this token");
            }

            RefreshToken refreshToken = member.RefreshTokens.Single(x => x.Token == token);

            //Refresh token is no longer active
            if(!refreshToken.IsActive)
            {
                throw new Exception("refresh token is expired");
            }

            //Revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;

            await _userManager.UpdateAsync(member);
        }
    }
}
