using Domain.Entities.PostgreSQL;
using Domain.Interfaces;
using Domain.Interfaces.Abstract;
using Domain.Interfaces.MongoDB;
using Domain.Interfaces.Read;
using Domain.Interfaces.Services;
using Domain.Interfaces.Write;
using Domain.PostgreSQL.Entities;
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
            services.AddTransient<IReadRepository<City>, ReadRepository<City>>();
            services.AddTransient<IReadRepository<Country>, ReadRepository<Country>>();
            services.AddTransient<IReadRepository<District>, ReadRepository<District>>();
            services.AddTransient<IEncumbranceReadRepository, EncumbranceReadRepository>();
            services.AddTransient<IReadRepository<Domain.PostgreSQL.Entities.Index>, ReadRepository<Domain.PostgreSQL.Entities.Index>>();
            services.AddTransient<IReadRepository<Region>, ReadRepository<Region>>();
            services.AddTransient<IReadRepository<Street>, ReadRepository<Street>>();
            services.AddTransient<IUserCommonReadRepository, UserCommonReadRepository>();
            services.AddTransient<IReadRepository<User>, ReadRepository<User>>();
            services.AddTransient<IReadRepository<Registrator>, ReadRepository<Registrator>>();
            services.AddTransient<IStatementReadRepository, StatementReadRepository>();
            services.AddTransient<IUserReadRepository, UserReadRepository>();
            services.AddTransient<IReadRepository<Authority>, ReadRepository<Authority>>();
            services.AddTransient<IAddressReadRepository, AddressReadRepository>();
            services.AddTransient<IReadRepository<EncumbranceParticipant>, ReadRepository<EncumbranceParticipant>>();
            services.AddTransient<IReadRepository<BasisDocument>, ReadRepository<BasisDocument>>();
            services.AddTransient<IEncumbranceObjectReadRepository, EncumbranceObjectReadRepository>();
            services.AddTransient<IReadRepository<EncumbranceTerms>, ReadRepository<EncumbranceTerms>>();
            services.AddTransient<IReadRepository<PassportAuthority>, ReadRepository<PassportAuthority>>();
            services.AddTransient<IReadRepository<Address>, ReadRepository<Address>>();
            services.AddTransient<IReadRepository<Registrator>, ReadRepository<Registrator>>();
            services.AddTransient<IReadRepository<StatementType>, ReadRepository<StatementType>>();
            services.AddTransient<IReadRepository<PassportInfo>, ReadRepository<PassportInfo>>();
            services.AddTransient<IReadRepository<Identificator>, ReadRepository<Identificator>>();
            services.AddTransient<IAddressReadRepository, AddressReadRepository>();
            services.AddTransient<IRegistratorActionReadRepository, RegistratorActionReadRepository>();

            services.AddTransient<IReadRepository<ExtractGettingActionsHistory>, ReadRepository<ExtractGettingActionsHistory>>();
            services.AddTransient<IReadRepository<RegistratorEncumbranceActionsHistory>, ReadRepository<RegistratorEncumbranceActionsHistory>>();
        }

        private static void AddWriteRepositories(this IServiceCollection services)
        {
            services.AddTransient<IWriteRepository<User>, WriteRepository<User>>();
            services.AddTransient<IWriteRepository<Registrator>, WriteRepository<Registrator>>();
            services.AddTransient<IUsersCommonWriteRepository, UsersCommonWriteRepository>();
            services.AddTransient<IStatementWriteRepository, StatementWriteRepository>();
            services.AddTransient<IWriteRepository<PassportInfo>, WriteRepository<PassportInfo>>();

            services.AddTransient<IWriteRepository<Encumbrance>, WriteRepository<Encumbrance>>();
            services.AddTransient<IWriteRepository<EncumbranceParticipant>, WriteRepository<EncumbranceParticipant>>();
            services.AddTransient<IWriteRepository<BasisDocument>, WriteRepository<BasisDocument>>();
            services.AddTransient<IWriteRepository<EncumbranceTerms>, WriteRepository<EncumbranceTerms>>();
            services.AddTransient<IMongoWriteRepository, EncumbranceObjectWriteRepository>();
            services.AddTransient<IWriteRepository<Address>, WriteRepository<Address>>();
            services.AddTransient<IWriteRepository<ExtractGettingActionsHistory>, WriteRepository<ExtractGettingActionsHistory>>();
            services.AddTransient<IWriteRepository<RegistratorEncumbranceActionsHistory>, WriteRepository<RegistratorEncumbranceActionsHistory>>();

            services.AddTransient<IEncumbranceObjectWriteRepository, EncumbranceObjectWriteRepository>();

            services.AddTransient<IWriteRepository<Registrator>, WriteRepository<Registrator>>();
            services.AddTransient<IWriteRepository<Identificator>, WriteRepository<Identificator>>();
            services.AddTransient<IUserRegistratorWriteRepository, UserRegistratorWriteRepository>();

            services.AddTransient<IPayementSertificateWriteRepository, PayementSertificateWriteRepository>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<ISmtpService, SmtpService>();
            services.AddTransient<IExtractGeneratorService, ExtractGeneratorService>();
            services.AddTransient<IRegistratorLogService, RegistratorLogService>();
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
            services.AddTransient<IMongoConnectionFactory, MongoConnectionFactory>();
        }
    }
}
