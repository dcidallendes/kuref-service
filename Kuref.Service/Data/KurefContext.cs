using System;
using Kuref.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Kuref.Service.Data
{
    public class KurefContext: DbContext
    {
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<MeasurementType> MeasurementTypes { get; set; }
        public DbSet<PhysicalDevice> PhysicalDevices { get; set; }
        public DbSet<PhysicalDeviceAssignation> PhysicalDeviceAssignations { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }

        public KurefContext(DbContextOptions<KurefContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhysicalDeviceAssignation>()
                .HasKey(p => new { p.MeasurementTypeId, p.PhysicalDeviceId, p.StationId });
            modelBuilder.Entity<ApiKey>()
                .HasIndex(a => a.Key)
                .IsUnique();
        }
    }
}
