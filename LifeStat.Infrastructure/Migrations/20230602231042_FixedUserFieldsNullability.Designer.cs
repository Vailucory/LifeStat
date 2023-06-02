﻿// <auto-generated />
using System;
using LifeStat.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LifeStat.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230602231042_FixedUserFieldsNullability")]
    partial class FixedUserFieldsNullability
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LifeStat.Infrastructure.Identity.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.ActivityDL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActivityTemplateId")
                        .HasColumnType("int");

                    b.Property<int?>("DailyPlanId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("EndTimeLocal")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("EndTimeUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("StartTimeLocal")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("StartTimeUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTemplateId");

                    b.HasIndex("DailyPlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.ActivityTemplateDL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ActivityTemplates");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.DailyPlanActivityDurationDL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActivityTemplateId")
                        .HasColumnType("int");

                    b.Property<int>("DailyPlanTemplateId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTemplateId");

                    b.HasIndex("DailyPlanTemplateId");

                    b.ToTable("DailyPlanActivityDurations");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.DailyPlanDL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DailyPlanTemplateId")
                        .HasColumnType("int");

                    b.Property<int>("FulfillmentStatus")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WeeklyPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DailyPlanTemplateId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeeklyPlanId");

                    b.ToTable("DailyPlans");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.DailyPlanTemplateDL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WeeklyPlanTemplateDLId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WeeklyPlanTemplateDLId");

                    b.ToTable("DailyPlanTemplates");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.UserDL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("CurrentActivityId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentDailyPlanId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentWeeklyPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.HasIndex("CurrentActivityId");

                    b.HasIndex("CurrentDailyPlanId");

                    b.HasIndex("CurrentWeeklyPlanId");

                    b.ToTable("InnerUsers");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.WeeklyPlanDL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FulfillmentStatus")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WeeklyPlanTemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WeeklyPlanTemplateId");

                    b.ToTable("WeeklyPlans");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.WeeklyPlanTemplateDL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WeeklyPlanTemplates");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.ActivityDL", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.ActivityTemplateDL", "Template")
                        .WithMany("Activities")
                        .HasForeignKey("ActivityTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.DailyPlanDL", "DailyPlan")
                        .WithMany("Activities")
                        .HasForeignKey("DailyPlanId");

                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.UserDL", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId");

                    b.Navigation("DailyPlan");

                    b.Navigation("Template");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.ActivityTemplateDL", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.UserDL", "User")
                        .WithMany("ActivityTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.DailyPlanActivityDurationDL", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.ActivityTemplateDL", "ActivityTemplate")
                        .WithMany("DailyPlanActivityDurations")
                        .HasForeignKey("ActivityTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.DailyPlanTemplateDL", "DailyPlanTemplate")
                        .WithMany("Activities")
                        .HasForeignKey("DailyPlanTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivityTemplate");

                    b.Navigation("DailyPlanTemplate");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.DailyPlanDL", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.DailyPlanTemplateDL", "DailyPlanTemplate")
                        .WithMany("DailyPlans")
                        .HasForeignKey("DailyPlanTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.UserDL", "User")
                        .WithMany("DailyPlans")
                        .HasForeignKey("UserId");

                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.WeeklyPlanDL", "WeeklyPlan")
                        .WithMany("DailyPlans")
                        .HasForeignKey("WeeklyPlanId");

                    b.Navigation("DailyPlanTemplate");

                    b.Navigation("User");

                    b.Navigation("WeeklyPlan");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.DailyPlanTemplateDL", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.UserDL", "User")
                        .WithMany("DailyPlanTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.WeeklyPlanTemplateDL", null)
                        .WithMany("DailyPlansTemplates")
                        .HasForeignKey("WeeklyPlanTemplateDLId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.UserDL", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Identity.ApplicationUser", "ApplicationUser")
                        .WithOne("InnerUser")
                        .HasForeignKey("LifeStat.Infrastructure.Persistence.Models.UserDL", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.ActivityDL", "CurrentActivity")
                        .WithMany()
                        .HasForeignKey("CurrentActivityId");

                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.DailyPlanDL", "CurrentDailyPlan")
                        .WithMany()
                        .HasForeignKey("CurrentDailyPlanId");

                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.WeeklyPlanDL", "CurrentWeeklyPlan")
                        .WithMany()
                        .HasForeignKey("CurrentWeeklyPlanId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("CurrentActivity");

                    b.Navigation("CurrentDailyPlan");

                    b.Navigation("CurrentWeeklyPlan");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.WeeklyPlanDL", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.UserDL", "User")
                        .WithMany("WeeklyPlans")
                        .HasForeignKey("UserId");

                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.WeeklyPlanTemplateDL", "WeeklyPlanTemplate")
                        .WithMany("WeeklyPlans")
                        .HasForeignKey("WeeklyPlanTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WeeklyPlanTemplate");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.WeeklyPlanTemplateDL", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Persistence.Models.UserDL", "User")
                        .WithMany("WeeklyPlanTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LifeStat.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("LifeStat.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Navigation("InnerUser")
                        .IsRequired();
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.ActivityTemplateDL", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("DailyPlanActivityDurations");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.DailyPlanDL", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.DailyPlanTemplateDL", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("DailyPlans");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.UserDL", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("ActivityTemplates");

                    b.Navigation("DailyPlanTemplates");

                    b.Navigation("DailyPlans");

                    b.Navigation("WeeklyPlanTemplates");

                    b.Navigation("WeeklyPlans");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.WeeklyPlanDL", b =>
                {
                    b.Navigation("DailyPlans");
                });

            modelBuilder.Entity("LifeStat.Infrastructure.Persistence.Models.WeeklyPlanTemplateDL", b =>
                {
                    b.Navigation("DailyPlansTemplates");

                    b.Navigation("WeeklyPlans");
                });
#pragma warning restore 612, 618
        }
    }
}
