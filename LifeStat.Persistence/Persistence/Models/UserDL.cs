using LifeStat.Infrastructure.Identity;

namespace LifeStat.Infrastructure.Persistence.Models;

public class UserDL
{
    public int Id { get; set; }

    public List<ActivityTemplateDL> ActivityTemplates { get; set; } = new();

    public List<DailyPlanTemplateDL> DailyPlanTemplates { get; set; } = new();

    public List<WeeklyPlanTemplateDL> WeeklyPlanTemplates { get; set; } = new();

    public List<ActivityDL> Activities { get; set; } = new();

    public List<DailyPlanDL> DailyPlans { get; set; } = new();

    public List<WeeklyPlanDL> WeeklyPlans { get; set; } = new();

    public ActivityDL CurrentActivity { get; set; } = new();

    public DailyPlanDL CurrentDailyPlan { get; set; } = new();

    public WeeklyPlanDL CurrentWeeklyPlan { get; set; } = new();

    #region Navigation Properties

    public ApplicationUser ApplicationUser { get; set; } = new();
    #endregion
}
