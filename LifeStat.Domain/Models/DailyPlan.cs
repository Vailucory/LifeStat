using Domain.Enums;

namespace Domain.Models;
public class DailyPlan
{
    public int Id { get; set; }

    public DailyPlanTemplate DailyPlanTemplate { get; set; } 

    public List<Activity> Activities { get; set; } = new();

    public PlanFulfillmentStatus FulfillmentStatus { get; set; }
}
