using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tracking.Backend.Models;

namespace Tracking.Backend.Data
{
    public class TrackingDbContext : DbContext
    {
        public TrackingDbContext(DbContextOptions<TrackingDbContext> options)
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
        public DbSet<Tracking.Backend.Models.WarrningStaff> WarrningStaff { get; set; }
        public DbSet<Tracking.Backend.Models.AssignRoute> AssignRoute { get; set; }
        public DbSet<Tracking.Backend.Models.WarningLog> WarningLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Identity
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(i => new { i.UserId, i.RoleId });
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins").HasKey(i => i.UserId);
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").HasKey(i => i.UserId);
        }
        public DbSet<Tracking.Backend.Models.User> User { get; set; }
        public DbSet<Tracking.Backend.Models.Role> Role { get; set; }
    }
}
