namespace LifeStat.Infrastructure.Persistence.Models;

public class DailyPlanActivityDurationDL
{
    public int Id { get; set; }

    public DailyPlanTemplateDL DailyPlanTemplate { get; set; } = new();

    public ActivityTemplateDL ActivityTemplate { get; set; } = new();

    public TimeSpan Duration { get; set; }

    #region NavigationProperties
    public int ActivityTemplateId { get; set; }

    public int DailyPlanTemplateId { get; set; }

    #endregion
}
