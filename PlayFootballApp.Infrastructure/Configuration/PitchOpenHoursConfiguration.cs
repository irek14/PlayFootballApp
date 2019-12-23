using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayFootballApp.BuisnessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.DataAccess.Configuration
{
    public class PitchOpenHoursConfiguration : IEntityTypeConfiguration<PitchOpenHours>
    {
        public void Configure(EntityTypeBuilder<PitchOpenHours> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(d => d.OpenHour)
                .WithMany(p => p.PitchOpenHours)
                .HasForeignKey(d => d.OpenHourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PitchOpenHours_OpenHour");

            builder.HasOne(d => d.Pitch)
                .WithMany(p => p.PitchOpenHours)
                .HasForeignKey(d => d.PitchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PitchOpenHours_Pitch");
        }
    }
}
