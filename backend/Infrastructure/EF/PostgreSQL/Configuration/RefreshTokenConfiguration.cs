using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.SetPropertiesRequired("Token");

            builder.HasOne(rt => rt.Identificator)
                .WithOne(rt => rt.RefreshToken)
                .HasForeignKey<Identificator>(i => i.RefreshTokenId)
                .HasConstraintName("FK_RefreshToken_Identificator")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
