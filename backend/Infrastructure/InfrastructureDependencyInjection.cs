using Domain.Interfaces;
using Domain.Interfaces.Read;
using Infrastructure.Dapper;
using Infrastructure.EF.PostgreSQL;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Read;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddPostgresDBContext();
            services.AddDapper();

            services.AddReadRepositories();
            services.AddWriteRepositories();
        }

        private static void AddReadRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAlienationLimitsReadRepository, AlienationLimitsReadRepository>();
            services.AddTransient<ICityReadRepository, CityReadRepository>();
            services.AddTransient<ICountryReadRepository, CountryReadRepository>();
            services.AddTransient<ICurrencyTypeReadRepository, CurrencyTypeReadRepository>();
            services.AddTransient<IDistrictReadRepository, DistrictReadRepository>();
            services.AddTransient<IEncumbranceKindReadRepository, EncumbranceKindReadRepository>();
            services.AddTransient<IEncumbranceReadRepository, EncumbranceReadRepository>();
            services.AddTransient<IEncumbranceTypeReadRepository, EncumbranceTypeReadRepository>();
            services.AddTransient<IIndexReadRepository, IndexReadRepository>();
            services.AddTransient<IRegionReadRepository, RegionReadRepository>();
            services.AddTransient<IRegistrationTypeReadRepository, RegistrationTypeReadRepository>();
            services.AddTransient<IRegistratorActionTypeReadRepository, RegistratorActionTypeReadRepository>();
            services.AddTransient<IStreetReadRepository, StreetReadRepository>();
            services.AddTransient<IUserCommonReadRepository, UserCommonReadRepository>();
            services.AddTransient<IUserRegistratorReadRepository, UserRegistratorReadRepository>();
        }

        private static void AddWriteRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRegistratorWriteRepository, UserRegistratorWriteRepository>();
            services.AddTransient<IUsersCommonWriteRepository, UsersCommonWriteRepository>();
        }

        private static void AddPostgresDBContext(this IServiceCollection services)
        {
            services.AddDbContext<EncumbrancesRegisterDbContext>(options =>
                options.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING"))
            );
        }

        private static void AddDapper(this IServiceCollection services)
        {
            services.AddTransient<PostgresConnectionFactory>(factory =>
                new PostgresConnectionFactory(Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING"))
            );
        }
    }
}
