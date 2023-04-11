namespace LifeStat.Persistence.Models;

public class WeeklyPlanTemplateDL
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<DailyPlanTemplateDL> DailyPlansTemplates { get; set; } = new();

    #region Navigation Properties
    public UserDL User { get; set; } = new();

    public int UserId { get; set; }

    public List<WeeklyPlanDL> WeeklyPlans { get; set; } = new();

    #endregion
}
