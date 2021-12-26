using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IJwtService
    {
        public Task<ClaimsIdentity> GetIdentity(string login, string password);
        public Task<string> GetJwtToken(string login, string password);
        public Guid? ValidateUserToken(string token);
        public ClaimsPrincipal GetTokenClaims(string token);
    }
}
