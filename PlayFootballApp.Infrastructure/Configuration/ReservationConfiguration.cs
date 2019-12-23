using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayFootballApp.BuisnessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.DataAccess.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Date).HasColumnType("date");

            builder.HasOne(d => d.PitchAvailability)
                .WithMany(p => p.Reservation)
                .HasForeignKey(d => d.PitchAvailabilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_PitchAvailability");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Reservation_User");
        }
    }
}
