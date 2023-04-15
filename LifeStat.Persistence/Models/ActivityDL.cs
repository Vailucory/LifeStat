namespace LifeStat.Persistence.Models;
public class ActivityDL
{
    public int Id { get; set; }

    public ActivityTemplateDL Template { get; set; } = new();
    public string Name { get; set; } = string.Empty;

    public DateTimeOffset StartTimeUtc { get; set; }

    public DateTimeOffset EndTimeUtc { get; set; }

    public DateTimeOffset StartTimeLocal { get; set; }

    public DateTimeOffset EndTimeLocal { get; set; }

    #region Navigation Properties
    public UserDL? User { get; set; } = new();

    public int? UserId { get; set; }

    public DailyPlanDL? DailyPlan { get; set; } = new();

    public int? DailyPlanId { get;set; }

    public int ActivityTemplateId { get; set; }
    #endregion
}
