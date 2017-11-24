
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CrossBackEnd.GeoLocation.Domain.Models;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Mapping
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States")
                .HasKey(s => s.StateId);

            builder.Property(s => s.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(s => s.Country)
                .WithMany(c => c.States)
                .HasForeignKey(s => s.CountryId)
                .HasConstraintName("FK_Countries_States")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}