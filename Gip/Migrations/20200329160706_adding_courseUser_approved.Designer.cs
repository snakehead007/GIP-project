﻿// <auto-generated />
using System;
using Gip.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gip.Migrations
{
    [DbContext(typeof(gipDatabaseContext))]
    [Migration("20200329160706_adding_courseUser_approved")]
    partial class adding_courseUser_approved
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gip.Models.Course", b =>
                {
                    b.Property<string>("Vakcode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Studiepunten")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Vakcode");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Gip.Models.CourseMoment", b =>
                {
                    b.Property<string>("Vakcode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gebouw")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Verdiep")
                        .HasColumnType("int");

                    b.Property<string>("Nummer")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Userid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Startmoment")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Eindmoment")
                        .HasColumnType("datetime2");

                    b.Property<string>("LessenLijst")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Vakcode", "Datum", "Gebouw", "Verdiep", "Nummer", "Userid", "Startmoment", "Eindmoment");

                    b.HasIndex("Userid");

                    b.HasIndex("Datum", "Startmoment", "Eindmoment");

                    b.HasIndex("Gebouw", "Verdiep", "Nummer");

                    b.ToTable("CourseMoment");
                });

            modelBuilder.Entity("Gip.Models.CourseUser", b =>
                {
                    b.Property<string>("Userid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Vakcode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.HasKey("Userid", "Vakcode");

                    b.HasIndex("Vakcode");

                    b.ToTable("CourseUser");
                });

            modelBuilder.Entity("Gip.Models.Room", b =>
                {
                    b.Property<string>("Gebouw")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Verdiep")
                        .HasColumnType("int");

                    b.Property<string>("Nummer")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capaciteit")
                        .HasColumnType("int");

                    b.Property<string>("Middelen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Gebouw", "Verdiep", "Nummer");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Gip.Models.Schedule", b =>
                {
                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Startmoment")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Eindmoment")
                        .HasColumnType("datetime2");

                    b.HasKey("Datum", "Startmoment", "Eindmoment");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("Gip.Models.User", b =>
                {
                    b.Property<string>("Userid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VoorNaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Userid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Gip.Models.CourseMoment", b =>
                {
                    b.HasOne("Gip.Models.User", "User")
                        .WithMany("CourseMoment")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gip.Models.Course", "VakcodeNavigation")
                        .WithMany("CourseMoment")
                        .HasForeignKey("Vakcode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gip.Models.Schedule", "Schedule")
                        .WithMany("CourseMoment")
                        .HasForeignKey("Datum", "Startmoment", "Eindmoment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gip.Models.Room", "Room")
                        .WithMany("CourseMoment")
                        .HasForeignKey("Gebouw", "Verdiep", "Nummer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gip.Models.CourseUser", b =>
                {
                    b.HasOne("Gip.Models.User", "User")
                        .WithMany("CourseUser")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gip.Models.Course", "VakcodeNavigation")
                        .WithMany("CourseUser")
                        .HasForeignKey("Vakcode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
