using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlayFootballApp.BuisnessEntities.Entities;
using PlayFootballApp.DataAccess.Configuration;

namespace PlayFootballApp.DataAccess
{
    public partial class PlayFootballContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public PlayFootballContext()
        {
        }

        public PlayFootballContext(DbContextOptions<PlayFootballContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OpenHour> OpenHour { get; set; }
        public virtual DbSet<Pitch> Pitch { get; set; }
        public virtual DbSet<PitchAvailability> PitchAvailability { get; set; }
        public virtual DbSet<PitchOpenHours> PitchOpenHours { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OpenHourConfiguration());
            modelBuilder.ApplyConfiguration(new PitchAvailabilityConfiguration());
            modelBuilder.ApplyConfiguration(new PitchConfiguration());
            modelBuilder.ApplyConfiguration(new PitchOpenHoursConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());

        }
    }
}
