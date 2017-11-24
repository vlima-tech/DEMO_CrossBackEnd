
using CrossBackEnd.GeoLocation.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Mapping
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities")
                .HasKey(c => c.CityId);

            builder.Property(c => c.Name)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(c => c.IsCapital)
                .IsRequired();

            builder.Property(c => c.Population)
                .IsRequired();

            builder.HasOne(c => c.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(c => c.StateId)
                .HasConstraintName("FK_States_Cities")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}