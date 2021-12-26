using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Infrastructure;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Services;
using Infrastructure.EF.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
            services.AddApplication();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddSession();
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "DevelopmentPolicy",
                    builder =>
                    {
                        builder
                            .WithHeaders("Authorization")
                            .WithHeaders("Content-Type")
                            .WithMethods("GET", "POST", "PUT", "DELETE")
                            .AllowAnyOrigin();
                    }
                );
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JWT_ISSUER"],

                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT_AUDIENCE"],

                        ValidateLifetime = true,

                        IssuerSigningKey = JwtService.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                }
            );


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseCors("DevelopmentPolicy");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
