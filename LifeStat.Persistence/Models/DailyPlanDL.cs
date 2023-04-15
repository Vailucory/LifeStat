using Domain.Enums;

namespace LifeStat.Persistence.Models;

public class DailyPlanDL
{
    public int Id { get; set; }

    public DailyPlanTemplateDL DailyPlanTemplate { get; set; } = new();

    public List<ActivityDL> Activities { get; set; } = new();

    public PlanFulfillmentStatus FulfillmentStatus { get; set; }

    #region Navigation Properties
    public UserDL? User { get; set; } = new();

    public int? UserId { get; set; }

    public int DailyPlanTemplateId { get; set; }

    public WeeklyPlanDL? WeeklyPlan { get; set; } = new();

    public int? WeeklyPlanId { get; set; }

    #endregion
}
