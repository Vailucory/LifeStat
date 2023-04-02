namespace Domain.Models;
public class User 
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public List<ActivityTemplate> ActivityTemplates { get; set; } = new();

    public List<DailyPlanTemplate> DailyPlanTemplates { get; set; } = new();

    public List<WeeklyPlanTemplate> WeeklyPlanTemplates { get; set; } = new();

    public List<Activity> Activities { get; set; } = new();

    public List<DailyPlan> DailyPlans { get; set; } = new();

    public List<WeeklyPlan> WeeklyPlans { get; set; } = new();

    public Activity CurrentActivity { get; set; } = new();

    public DailyPlan CurrentDailyPlan { get; set; } = new();

    public WeeklyPlan CurrentWeeklyPlan { get; set; } = new();
}
