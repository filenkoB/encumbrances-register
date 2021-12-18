using Application.Enumerations;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IUserCommonReadRepository _userCommonReadRepository;
        private static IConfiguration _configuration;
        public JwtService(IUserCommonReadRepository userCommonReadRepository, IConfiguration configuration)
        {
            _userCommonReadRepository = userCommonReadRepository;
            _configuration = configuration;
        }

        public async Task<string> GetJwtToken(string login, string password)
        {
            ClaimsIdentity identity = await GetIdentity(login, password);

            if (identity is null)
            {
                return null;
            }
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: _configuration["JWT_ISSUER"],
                audience: _configuration["JWT_AUDIENCE"],
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(Double.Parse(_configuration["JWT_LIFETIME"]))),
                signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );
            
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<ClaimsIdentity> GetIdentity(string login, string password)
        {
            Guid userId = await _userCommonReadRepository.GetUserByCredentialsAsync(login, password);
            if (userId == default)
            {
                return null;
            }

            UserType userType = await _userCommonReadRepository.GetUserTypeByIdentificatorAsync(login);

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userType.ToString())
            };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT_KEY"]));
        }
    }
}
