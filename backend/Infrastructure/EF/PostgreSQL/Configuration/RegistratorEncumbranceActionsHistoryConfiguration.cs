using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class RegistratorEncumbranceActionsHistoryConfiguration : IEntityTypeConfiguration<RegistratorEncumbranceActionsHistory>
    {
        public void Configure(EntityTypeBuilder<RegistratorEncumbranceActionsHistory> builder)
        {
            builder.HasOne(reah => reah.RegistratorActionType)
                .WithMany(rat => rat.RegistratorEncumbranceActions)
                .HasForeignKey(reah => reah.RegistratorActionTypeId)
                .HasConstraintName("FK_RegistrationActionType_RegistratorEAHistory")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
