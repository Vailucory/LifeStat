using Domain.Enums;

namespace Domain.Models;
public class WeeklyPlan
{
    public int Id { get; set; }

    public WeeklyPlanTemplate WeeklyPlanTemplate { get; set; } = new();

    public List<DailyPlan> DailyPlans { get; set; } = new();

    public PlanFulfillmentStatus FulfillmentStatus { get; set; }
}
