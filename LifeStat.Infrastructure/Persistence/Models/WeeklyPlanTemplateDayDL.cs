namespace LifeStat.Infrastructure.Persistence.Models;
public class WeeklyPlanTemplateDayDL
{
    public int Id { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public DailyPlanTemplateDL DailyPlanTemplate { get; set; }

    public WeeklyPlanTemplateDL WeeklyPlanTemplate { get; set; }

    #region Navigation Properties
    public int DailyPlanTemplateId { get; set; }

    public int WeeklyPlanTemplateId { get; set; }
    #endregion
}
