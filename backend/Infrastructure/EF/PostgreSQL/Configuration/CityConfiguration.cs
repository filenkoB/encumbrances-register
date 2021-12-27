using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasMany(c => c.Addresses)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId)
                .HasConstraintName("FK_City_Addresses")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(c => c.District)
                .WithMany(d => d.Cities)
                .HasForeignKey(c => c.DistrictId)
                .HasConstraintName("FK_District_Cities")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(c => c.Indices)
                .WithOne(i => i.City)
                .HasForeignKey(i => i.CityId)
                .HasConstraintName("FK_City_Indices")
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}