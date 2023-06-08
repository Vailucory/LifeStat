namespace LifeStat.Infrastructure.Persistence.Models;

public class DailyPlanTemplateDL
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<DailyPlanActivityDurationDL> Activities { get; set; } = new();

    #region Navigation Properties
    public UserDL User { get; set; } 

    public int UserId { get; set; }

    public List<DailyPlanDL> DailyPlans { get; set; } = new();

    public List<WeeklyPlanTemplateDayDL> WeeklyPlanTemplateDays { get; set; } = new();

    #endregion
}
