
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.GeoLocation.Infra.Server.Data.Mapping;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Context
{
    public class GeoLocation_Context : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new CityMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseSqlServer(config.GetConnectionString("VW_Connection"));
        }
    }
}