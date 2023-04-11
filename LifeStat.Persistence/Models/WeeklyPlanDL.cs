using Domain.Enums;

namespace LifeStat.Persistence.Models;

public class WeeklyPlanDL
{
    public int Id { get; set; }

    public WeeklyPlanTemplateDL WeeklyPlanTemplate { get; set; } = new();

    public List<DailyPlanDL> DailyPlans { get; set; } = new();

    public PlanFulfillmentStatus FulfillmentStatus { get; set; }

    #region Navigation Properties
    public UserDL User { get; set; } = new();

    public int UserId { get; set; }

    public int WeeklyPlanTemplateId { get; set; }

    #endregion
}
