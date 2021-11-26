using Microsoft.EntityFrameworkCore;
using Domain.PostgreSQL.Entities;
using PostgresEntities = Domain.PostgreSQL.Entities;
using System.Reflection;

namespace Infrastructure.EF.PostgreSQL
{
    public class EncumbrancesRegisterDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AlienationLimit> AlienationLimits { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<BasisDocument> BasisDocuments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Encumbrance> Encumbrances { get; set; }
        public DbSet<EncumbranceKind> EncumbranceKinds { get; set; }
        public DbSet<EncumbranceParticipant> EncumbranceParticipants { get; set; }
        public DbSet<EncumbranceTerms> EncumbranceTerms { get; set; }
        public DbSet<EncumbranceType> EncumbranceTypes { get; set; }
        public DbSet<ExtractGettingActionsHistory> ExtractGettingActionsHistory { get; set; }
        public DbSet<Identificator> Identificators { get; set; }
        public DbSet<PostgresEntities.Index> Indices { get; set; }
        public DbSet<PassportInfo> PassportInfos { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RegistrationType> RegistrationTypes { get; set; }
        public DbSet<Registrator> Registrators { get; set; }
        public DbSet<RegistratorActionType> RegistratorActionTypes { get; set; }
        public DbSet<RegistratorEncumbranceActionsHistory> RegistratorEncumbranceActionsHistory { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<TaxpayerAccountCardNumber> TaxpayerAccountCardNumbers { get; set; }
        public DbSet<User> Users { get; set; }

        public EncumbrancesRegisterDbContext(DbContextOptions<EncumbrancesRegisterDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Encumbrances_Register_DB;Username=postgres;Password=3497279088");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

    }
}
