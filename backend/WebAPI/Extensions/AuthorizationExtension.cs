using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Extensions
{
    public static class AuthorizationExtension
    {
        public static void ConfigureAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JWT_ISSUER"],

                        ValidateAudience = true,
                        ValidAudience = configuration["JWT_AUDIENCE"],

                        ValidateLifetime = true,

                        IssuerSigningKey = JwtService.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                }
            );
        }
    }
}
