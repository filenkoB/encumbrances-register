using Application.Enumerations;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IUserCommonReadRepository _userCommonReadRepository;
        public JwtService(IUserCommonReadRepository userCommonReadRepository)
        {
            _userCommonReadRepository = userCommonReadRepository;
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
                issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
                audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(Double.Parse(Environment.GetEnvironmentVariable("JWT_LIFETIME")))),
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
                new Claim("UserId", userId.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userType.ToString())
            };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")));
        }

        public Guid? ValidateUserToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal claims = null;
            try
            {
                claims = tokenHandler.ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY"))),
                    }, out SecurityToken validatedToken
                );
            }
            catch
            {
                return null;
            }

            string userIdClaim = claims.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            return userIdClaim == default ? null : Guid.Parse(userIdClaim);
        }

        public ClaimsPrincipal GetTokenClaims(string token)
        {
            try
            {
                return new JwtSecurityTokenHandler().ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY"))),
                    }, out SecurityToken validatedToken
                );
            }
            catch
            {
                return null;
            }
        }
    }
}
