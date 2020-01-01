using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayFootballApp.BuisnessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.DataAccess.Configuration
{
    public class PitchConfiguration : IEntityTypeConfiguration<Pitch>
    {
        public void Configure(EntityTypeBuilder<Pitch> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.LocalisationX).HasColumnType("decimal(25, 15)");

            builder.Property(e => e.LocalisationY).HasColumnType("decimal(25, 15)");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsFixedLength();

            builder.Property(e => e.SpotNumber).HasColumnType("numeric(18, 0)");
        }
    }
}
