using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class RegistratorConfiguration : IEntityTypeConfiguration<Registrator>
    {
        public void Configure(EntityTypeBuilder<Registrator> builder)
        {
            builder.HasOne(r => r.PassportInfo)
                .WithOne(pi => pi.Registrator)
                .HasForeignKey<Registrator>(r => r.PassportInfoId)
                .HasConstraintName("FK_Registrator_PassportInfo")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Identificator)
                .WithOne(i => i.Registrator)
                .HasForeignKey<Registrator>(r => r.IdentificatorId)
                .HasConstraintName("FK_Registrator_Identificator")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.ExtractGettingActions)
                .WithOne(ega => ega.IssuerRegistrator)
                .HasForeignKey(ega => ega.IssuerId)
                .HasConstraintName("FK_Registrator_ExtractGettingActions")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.RegistratorEncumbranceActions)
                .WithOne(rea => rea.Registrator)
                .HasForeignKey(rea => rea.RegistratorId)
                .HasConstraintName("FK_Registrator_RegistratorEncumbranceActions")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
