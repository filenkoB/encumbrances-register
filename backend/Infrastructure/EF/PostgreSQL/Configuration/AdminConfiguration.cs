using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasOne(a => a.PassportInfo)
                .WithOne(pi => pi.Admin)
                .HasForeignKey<Admin>(a => a.PassportInfoId)
                .HasConstraintName("FK_Admin_PassportInfo")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Identificator)
                .WithOne(i => i.Admin)
                .HasForeignKey<Admin>(a => a.IdentificatorId)
                .HasConstraintName("FK_Admin_Identificator")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
