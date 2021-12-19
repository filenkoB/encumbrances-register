using Domain.Interfaces;
using Domain.Interfaces.MongoDB;
using Domain.Interfaces.Read;
using Domain.Interfaces.Services;
using Domain.Interfaces.Write;
using Infrastructure.Dapper;
using Infrastructure.EF.PostgreSQL;
using Infrastructure.MongoDB;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Read;
using Infrastructure.Repositories.Write;
using Infrastructure.Services;
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
            services.AddMongoDB();

            services.AddServices();
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
            services.AddTransient<IStatementReadRepository, StatementReadRepository>();
            services.AddTransient<IStatementTypeReadRepository, StatementTypeReadRepository>();
        }

        private static void AddWriteRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRegistratorWriteRepository, UserRegistratorWriteRepository>();
            services.AddTransient<IUsersCommonWriteRepository, UsersCommonWriteRepository>();
            services.AddTransient<IStatementWriteRepository, StatementWriteRepository>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IJwtService, JwtService>();
        }

        private static void AddPostgresDBContext(this IServiceCollection services)
        {
            services.AddDbContext<EncumbrancesRegisterDbContext>(options =>
                options.UseNpgsql("Host=ec2-3-248-87-6.eu-west-1.compute.amazonaws.com;Port=5432;Database=d99eufmq97gniv;Username=tgmkclnueetwkj;Password=d5b69e55a15eaad84381845329ff8493fa3977c7aa06fa68fa2971ae30414a18;Trust Server Certificate=true;sslmode=Require")
            );
        }

        private static void AddDapper(this IServiceCollection services)
        {
            services.AddTransient<PostgresConnectionFactory>(factory =>
                new PostgresConnectionFactory(Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING"))
            );
        }

        private static void AddMongoDB(this IServiceCollection services)
        {
            services.AddSingleton<IMongoConnectionFactory, MongoConnectionFactory>();
        }
    }
}
