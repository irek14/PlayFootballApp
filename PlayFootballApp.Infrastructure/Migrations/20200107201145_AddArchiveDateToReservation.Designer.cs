﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayFootballApp.DataAccess;

namespace PlayFootballApp.DataAccess.Migrations
{
    [DbContext(typeof(PlayFootballContext))]
    [Migration("20200107201145_AddArchiveDateToReservation")]
    partial class AddArchiveDateToReservation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubscriberId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.Pitch", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<decimal>("LocalisationX")
                        .HasColumnType("decimal(25, 15)");

                    b.Property<decimal>("LocalisationY")
                        .HasColumnType("decimal(25, 15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nchar(255)")
                        .IsFixedLength(true)
                        .HasMaxLength(255);

                    b.Property<Guid?>("OpenHoursId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("SpotNumber")
                        .HasColumnType("numeric(18, 0)");

                    b.HasKey("Id");

                    b.ToTable("Pitch");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.PitchAvailability", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("date");

                    b.Property<Guid>("PitchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PitchOpenHoursId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ReservedPlaces")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PitchId");

                    b.HasIndex("PitchOpenHoursId");

                    b.ToTable("PitchAvailability");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.PitchOpenHours", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EndHour")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<Guid>("PitchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StartHour")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<decimal>("WeekDay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PitchId");

                    b.ToTable("PitchOpenHours");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CancelDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<Guid>("PitchAvailabilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ReservedSpots")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PitchAvailabilityId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationRoleClaim", b =>
                {
                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationUserClaim", b =>
                {
                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationUserLogin", b =>
                {
                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.ApplicationUserToken", b =>
                {
                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.PitchAvailability", b =>
                {
                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.Pitch", "Pitch")
                        .WithMany("PitchAvailability")
                        .HasForeignKey("PitchId")
                        .HasConstraintName("FK_PitchAvailability_Pitch")
                        .IsRequired();

                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.PitchOpenHours", "PitchOpenHours")
                        .WithMany("PitchAvailability")
                        .HasForeignKey("PitchOpenHoursId")
                        .HasConstraintName("FK_PitchAvailability_PitchOpenHours")
                        .IsRequired();
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.PitchOpenHours", b =>
                {
                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.Pitch", "Pitch")
                        .WithMany("PitchOpenHours")
                        .HasForeignKey("PitchId")
                        .HasConstraintName("FK_PitchOpenHours_Pitch")
                        .IsRequired();
                });

            modelBuilder.Entity("PlayFootballApp.BuisnessEntities.Entities.Reservation", b =>
                {
                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.PitchAvailability", "PitchAvailability")
                        .WithMany("Reservation")
                        .HasForeignKey("PitchAvailabilityId")
                        .HasConstraintName("FK_Reservation_PitchAvailability")
                        .IsRequired();

                    b.HasOne("PlayFootballApp.BuisnessEntities.Entities.ApplicationUser", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Reservation_User")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
