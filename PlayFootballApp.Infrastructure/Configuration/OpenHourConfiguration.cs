using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayFootballApp.BuisnessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.DataAccess.Configuration
{
    public class OpenHourConfiguration : IEntityTypeConfiguration<OpenHour>
    {
        public void Configure(EntityTypeBuilder<OpenHour> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.EndHour)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();

            builder.Property(e => e.StartHour)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();
        }
    }
}
