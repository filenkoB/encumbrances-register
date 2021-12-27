using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasMany(d => d.Addresses)
                .WithOne(a => a.District)
                .HasForeignKey(a => a.DistrictId)
                .HasConstraintName("FK_District_Addresses")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Region)
                .WithMany(r => r.Districts)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_Region_Districts")
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}