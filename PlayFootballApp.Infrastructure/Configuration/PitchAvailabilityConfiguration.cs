using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayFootballApp.BuisnessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.DataAccess.Configuration
{
    public class PitchAvailabilityConfiguration : IEntityTypeConfiguration<PitchAvailability>
    {
        public void Configure(EntityTypeBuilder<PitchAvailability> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.OpenDate).HasColumnType("date");

            builder.HasOne(d => d.Pitch)
                .WithMany(p => p.PitchAvailability)
                .HasForeignKey(d => d.PitchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PitchAvailability_Pitch");

            builder.HasOne(d => d.PitchOpenHours)
                .WithMany(p => p.PitchAvailability)
                .HasForeignKey(d => d.PitchOpenHoursId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PitchAvailability_PitchOpenHours");
        }
    }
}
