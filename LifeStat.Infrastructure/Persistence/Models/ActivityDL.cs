namespace LifeStat.Infrastructure.Persistence.Models;
public class ActivityDL
{
    public int Id { get; set; }

    public ActivityTemplateDL Template { get; set; } 
    public string Name { get; set; } = string.Empty;

    public DateTimeOffset StartTimeUtc { get; set; }

    public DateTimeOffset EndTimeUtc { get; set; }

    public DateTimeOffset StartTimeLocal { get; set; }

    public DateTimeOffset EndTimeLocal { get; set; }

    #region Navigation Properties
    public UserDL? User { get; set; }

    public int? UserId { get; set; }

    public DailyPlanDL? DailyPlan { get; set; }

    public int? DailyPlanId { get; set; }

    public int ActivityTemplateId { get; set; }
    #endregion
}
