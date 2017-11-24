
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CrossBackEnd.GeoLocation.Domain.Models;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Mapping
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries")
                .HasKey(c => c.CountryId);

            builder.Property(c => c.Abbreviation)
                .IsRequired(false);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}