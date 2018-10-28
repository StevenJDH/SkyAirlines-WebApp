using Microsoft.EntityFrameworkCore;
using SkyAirlines.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyAirlines.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Manifest> Manifests { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasIndex(e => e.AirportCode).IsUnique();
                entity.HasIndex(e => e.AirportName).IsUnique();
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => new {
                    e.FlightPrefix,
                    e.FlightId
                });

                entity.HasOne(d => d.Aircraft)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AircraftId);

                entity.HasOne(d => d.Airport)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirportId);
            });

            modelBuilder.Entity<Manifest>(entity =>
            {
                entity.HasKey(e => new {
                    e.FlightPrefix,
                    e.FlightId,
                    e.PassengerId
                });

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Manifests)
                    .HasForeignKey(d => d.PassengerId);

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Manifests)
                    .HasForeignKey(d => new { d.FlightPrefix, d.FlightId });
            });

            // EF Core 2.1+ Approach for a formal Database Initializer and refactored to use an extention.
            modelBuilder.Seed(); 

            base.OnModelCreating(modelBuilder);
        }

    }
}
