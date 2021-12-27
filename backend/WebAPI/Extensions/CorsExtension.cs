using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            return services.AddCors(options =>
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
        }
    }
}
