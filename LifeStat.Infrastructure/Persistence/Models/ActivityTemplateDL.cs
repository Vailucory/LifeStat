using Domain.Enums;

namespace LifeStat.Infrastructure.Persistence.Models;

public class ActivityTemplateDL
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ActivityType Type { get; set; }

    #region Navigation Properties
    public List<ActivityDL> Activities { get; set; } = new();

    public UserDL User { get; set; } = new();

    public int UserId { get; set; }

    public List<DailyPlanActivityDurationDL> DailyPlanActivityDurations { get; set; } = new();

    #endregion
}
