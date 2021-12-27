using Domain.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.PostgreSQL.Configuration
{
    public static class ConfigurationExtensions
    {
        public static EntityTypeBuilder SetPropertiesRequired(this EntityTypeBuilder builder, params string[] properties) 
        {
            foreach (var property in properties)
            {
                builder.Property(property)
                    .IsRequired();
            }
            return builder;
        }
    }
}
