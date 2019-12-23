using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayFootballApp.BuisnessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.DataAccess.Configuration
{
    class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>    {


        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("USR_User");
            builder.HasAnnotation("Prefix", "USR");
            builder.Property(p => p.SubscriberId).HasColumnName("SUB_SubscriberId");

            builder.Property(p => p.FirstName).HasMaxLength(30);
            builder.Property(p => p.LastName).HasMaxLength(50);
        }
    }
}
