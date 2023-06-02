using Domain.Enums;

namespace LifeStat.Infrastructure.Persistence.Models;

public class DailyPlanDL
{
    public int Id { get; set; }

    public DailyPlanTemplateDL DailyPlanTemplate { get; set; } 

    public List<ActivityDL> Activities { get; set; } = new();

    public PlanFulfillmentStatus FulfillmentStatus { get; set; }

    #region Navigation Properties
    public UserDL? User { get; set; } 

    public int? UserId { get; set; }

    public int DailyPlanTemplateId { get; set; }

    public WeeklyPlanDL? WeeklyPlan { get; set; } 

    public int? WeeklyPlanId { get; set; }

    #endregion
}
