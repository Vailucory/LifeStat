namespace LifeStat.Persistence.Models;

public class UserDL 
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

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


    #endregion
}
