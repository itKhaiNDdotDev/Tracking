using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tracking.Backend.Models;

namespace Tracking.Backend.Data
{
    public class TrackingDbContext : DbContext
    {
        public TrackingDbContext (DbContextOptions<TrackingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tracking.Backend.Models.AtmTechnican> AtmTechnican { get; set; }

        public DbSet<Tracking.Backend.Models.Car> Car { get; set; }

        public DbSet<Tracking.Backend.Models.Device> Device { get; set; }

        public DbSet<Tracking.Backend.Models.Driver> Driver { get; set; }

        public DbSet<Tracking.Backend.Models.ManageUnit> ManageUnit { get; set; }

        public DbSet<Tracking.Backend.Models.Rfid> Rfid { get; set; }

        public DbSet<Tracking.Backend.Models.TransactionPoint> TransactionPoint { get; set; }

        public DbSet<Tracking.Backend.Models.Treasurer> Treasurer { get; set; }
        public DbSet<Tracking.Backend.Models.SampleRoute> SampleRoutes { get; set; }
    }
}
