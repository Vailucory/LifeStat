namespace LifeStat.Infrastructure.Persistence.Models;

public class DailyPlanActivityDurationDL
{
    public int Id { get; set; }

    public DailyPlanTemplateDL DailyPlanTemplate { get; set; } 

    public ActivityTemplateDL ActivityTemplate { get; set; } 

    public TimeSpan Duration { get; set; }

    #region NavigationProperties
    public int ActivityTemplateId { get; set; }

    public int DailyPlanTemplateId { get; set; }

    #endregion
}
