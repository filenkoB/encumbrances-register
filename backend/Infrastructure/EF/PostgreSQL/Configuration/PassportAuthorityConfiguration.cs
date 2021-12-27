using Domain.Entities.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public class PassportAuthorityConfiguration : IEntityTypeConfiguration<PassportAuthority>
    {
        public void Configure(EntityTypeBuilder<PassportAuthority> builder)
        {
            builder.HasMany(a => a.PassportInfos)
                .WithOne(pi => pi.Authority)
                .HasForeignKey(pi => pi.AuthorityId)
                .HasConstraintName("FK_PassportAuthority_PassportInfos")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
