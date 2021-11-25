using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.SetPropertiesRequired("FirstName", "LastName", "BirthDate", "Email", "IsForeigner");

            builder.HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<User>(u => u.AddressId)
                .HasConstraintName("FK_User_Address")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.TaxpayerAccountCardNumber)
                .WithOne(tpan => tpan.User)
                .HasForeignKey<User>(u => u.TaxpayerAccountCardNumberId)
                .HasConstraintName("FK_User_TaxpayerAccountCardNumber")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(u => u.PassportInfo)
                .WithOne(pi => pi.User)
                .HasForeignKey<User>(u => u.PassportInfoId)
                .HasConstraintName("FK_User_PassportInfo")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Identificator)
                .WithOne(i => i.User)
                .HasForeignKey<User>(u => u.IdentificatorId)
                .HasConstraintName("FK_User_Identificator")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.ExtractGettingActions)
                .WithOne(ega => ega.IssuerUser)
                .HasForeignKey(ega => ega.IssuerId)
                .HasConstraintName("FK_User_ExtractGettingActions")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Authority)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.Authorityid)
                .HasConstraintName("FK_Authority_Users")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
