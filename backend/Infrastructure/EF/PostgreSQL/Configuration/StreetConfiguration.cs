using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class StreetConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.HasMany(s => s.Addresses)
                .WithOne(a => a.Street)
                .HasForeignKey(a => a.StreetId)
                .HasConstraintName("FK_Street_Addresses")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(s => s.City)
                .WithMany(c => c.Streets)
                .HasForeignKey(s => s.CityId)
                .HasConstraintName("FK_City_Streets")
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}