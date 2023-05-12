using LifeStat.Infrastructure.Identity;
using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Infrastructure.Persistence;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public DbSet<ActivityDL> Activities { get; set; }
    public DbSet<ActivityTemplateDL> ActivityTemplates { get; set; }
    public DbSet<DailyPlanActivityDurationDL> DailyPlanActivityDurations { get; set; }
    public DbSet<DailyPlanDL> DailyPlans { get; set; }
    public DbSet<DailyPlanTemplateDL> DailyPlanTemplates { get; set; }
    public DbSet<UserDL> InnerUsers { get; set; }
    public DbSet<WeeklyPlanDL> WeeklyPlans { get; set; }
    public DbSet<WeeklyPlanTemplateDL> WeeklyPlanTemplates { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Relations
        modelBuilder.Entity<ApplicationUser>()
            .HasOne(au => au.InnerUser)
            .WithOne(u => u.ApplicationUser);

        modelBuilder.Entity<ActivityTemplateDL>()
            .HasOne(at => at.User)
            .WithMany(u => u.ActivityTemplates)
            .HasForeignKey(at => at.UserId);

        modelBuilder.Entity<WeeklyPlanTemplateDL>()
            .HasOne(wpt => wpt.User)
            .WithMany(u => u.WeeklyPlanTemplates)
            .HasForeignKey(wpt => wpt.UserId);

        modelBuilder.Entity<DailyPlanTemplateDL>()
            .HasOne(dpt => dpt.User)
            .WithMany(u => u.DailyPlanTemplates)
            .HasForeignKey(dpt => dpt.UserId);

        #region ActivityDL
        modelBuilder.Entity<ActivityDL>()
            .HasOne(a => a.User)
            .WithMany(u => u.Activities)
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<ActivityDL>()
            .HasOne(a => a.Template)
            .WithMany(t => t.Activities)
            .HasForeignKey(a => a.ActivityTemplateId);

        modelBuilder.Entity<ActivityDL>()
            .HasOne(a => a.DailyPlan)
            .WithMany(dp => dp.Activities)
            .HasForeignKey(a => a.DailyPlanId);

        #endregion

        #region DailyPlanActivityDurationDL
        modelBuilder.Entity<DailyPlanActivityDurationDL>()
            .HasOne(ad => ad.ActivityTemplate)
            .WithMany(at => at.DailyPlanActivityDurations)
            .HasForeignKey(ad => ad.ActivityTemplateId);

        modelBuilder.Entity<DailyPlanActivityDurationDL>()
            .HasOne(ad => ad.DailyPlanTemplate)
            .WithMany(dpt => dpt.Activities)
            .HasForeignKey(ad => ad.DailyPlanTemplateId);

        #endregion

        #region DailyPlanDL
        modelBuilder.Entity<DailyPlanDL>()
            .HasOne(dp => dp.User)
            .WithMany(u => u.DailyPlans)
            .HasForeignKey(dp => dp.UserId);

        modelBuilder.Entity<DailyPlanDL>()
            .HasOne(dp => dp.DailyPlanTemplate)
            .WithMany(dpt => dpt.DailyPlans)
            .HasForeignKey(dp => dp.DailyPlanTemplateId);

        modelBuilder.Entity<DailyPlanDL>()
            .HasOne(dp => dp.WeeklyPlan)
            .WithMany(wp => wp.DailyPlans)
            .HasForeignKey(dp => dp.WeeklyPlanId);

        #endregion

        #region WeeklyPlanDL
        modelBuilder.Entity<WeeklyPlanDL>()
            .HasOne(wp => wp.User)
            .WithMany(u => u.WeeklyPlans)
            .HasForeignKey(wp => wp.UserId);

        modelBuilder.Entity<WeeklyPlanDL>()
            .HasOne(wp => wp.WeeklyPlanTemplate)
            .WithMany(wpt => wpt.WeeklyPlans)
            .HasForeignKey(wp => wp.WeeklyPlanTemplateId);

        #endregion

        #endregion
    }
}
