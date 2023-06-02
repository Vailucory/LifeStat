namespace Domain.Models;
public class DailyPlanActivityDuration
{
    public int Id { get; set; }

    public DailyPlanTemplate DailyPlanTemplate { get; set; }

    public ActivityTemplate ActivityTemplate { get; set; } 

    public TimeSpan Duration { get; set; }
}
