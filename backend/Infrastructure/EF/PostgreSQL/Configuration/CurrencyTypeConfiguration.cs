using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class CurrencyTypeConfiguration : IEntityTypeConfiguration<CurrencyType>
    {
        public void Configure(EntityTypeBuilder<CurrencyType> builder)
        {
            builder.HasMany(ct => ct.EncumbranceTerms)
                .WithOne(et => et.CurrencyType)
                .HasForeignKey(et => et.CurrencyTypeId)
                .HasConstraintName("FK_CurrencyType_EncumbranceTerms");
        }
    }
}
