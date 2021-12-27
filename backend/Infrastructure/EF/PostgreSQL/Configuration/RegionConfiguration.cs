using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasMany(r => r.Addresses)
                .WithOne(a => a.Region)
                .HasForeignKey(a => a.RegionId)
                .HasConstraintName("FK_Region_Addresses")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(r => r.Country)
                .WithMany(c => c.Regions)
                .HasForeignKey(r => r.CountryId)
                .HasConstraintName("FK_Country_Regions")
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}