using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class EncumbranceConfiguration : IEntityTypeConfiguration<Encumbrance>
    {
        public void Configure(EntityTypeBuilder<Encumbrance> builder)
        {
            builder.HasOne(e => e.Tier)
                .WithOne(ep => ep.EncumbranceToTier)
                .HasForeignKey<Encumbrance>(e => e.TierId)
                .HasConstraintName("FK_Encumbrance_Tier")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Debtor)
                .WithOne(ep => ep.EncumbranceToDebtor)
                .HasForeignKey<Encumbrance>(e => e.DebtorId)
                .HasConstraintName("FK_Encumbrance_Debtor")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.BasisDocument)
                .WithOne(bd => bd.Encumbrance)
                .HasForeignKey<Encumbrance>(e => e.BasisDocumentId)
                .HasConstraintName("FK_Encumbrance_BasisDocument")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.EncumbranceTerms)
                .WithOne(et => et.Encumbrance)
                .HasForeignKey<Encumbrance>(e => e.TermsId)
                .HasConstraintName("FK_Encumbrance_Terms")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.EncumbranceKind)
                .WithMany(ek => ek.Encumbrances)
                .HasForeignKey(e => e.KindId)
                .HasConstraintName("FK_EncumbranceKind_Encumbrances")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.RegistrationType)
                .WithMany(rt => rt.Encumbrances)
                .HasForeignKey(e => e.RegistrationTypeId)
                .HasConstraintName("FK_RegistrationType_Encumbrances")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.EncumbranceType)
                .WithMany(et => et.Encumbrances)
                .HasForeignKey(e => e.TypeId)
                .HasConstraintName("FK_EncumbranceType_Encumbrances")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.AlienationLimit)
                .WithMany(ek => ek.Encumbrances)
                .HasForeignKey(e => e.AlienationLimitId)
                .HasConstraintName("FK_AlienationLimit_Encumbrances")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.ExtractGettingActions)
                .WithOne(ega => ega.Encumbrance)
                .HasForeignKey(e => e.EncumbranceId)
                .HasConstraintName("FK_Encumbrance_ExtractGettingActions")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
