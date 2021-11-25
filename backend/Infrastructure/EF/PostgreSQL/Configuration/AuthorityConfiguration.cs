using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class AuthorityConfiguration : IEntityTypeConfiguration<Authority>
    {
        public void Configure(EntityTypeBuilder<Authority> builder)
        {
            builder.HasOne(a => a.Address)
                .WithOne(a => a.Authority)
                .HasForeignKey<Authority>(a => a.AddressId)
                .HasConstraintName("FK_Authority_Address")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.PassportInfos)
                .WithOne(pi => pi.Authority)
                .HasForeignKey(pi => pi.AuthorityId)
                .HasConstraintName("FK_Authority_PassportInfos")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.Registrators)
                .WithOne(r => r.Authority)
                .HasForeignKey(r => r.AuthorityId)
                .HasConstraintName("FK_Authority_Registrators")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.Admins)
                .WithOne(a => a.Authority)
                .HasForeignKey(a => a.AuthorityId)
                .HasConstraintName("FK_Authority_Admins")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
