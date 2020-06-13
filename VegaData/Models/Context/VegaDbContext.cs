using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaData.Models.Context
{
    public class VegaDbContext: DbContext
    {
        public DbSet <Make> Makes { get; set; }
        public DbSet <Models> Models { get; set; }
        public DbSet <Feature> Features { get; set; }
        public DbSet <Vehicle> Vehicles { get; set; }
        public DbSet <VehicleFeature> VehicleFeatures { get; set; }

        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>()
                .HasKey(vf => new { vf.VehicleId, vf.FeatureId });
        }
    }
}
