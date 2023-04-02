namespace Domain.Models;
public class DailyPlanActivityDuration
{
    public int Id { get; set; }

    public DailyPlanTemplate DailyPlanTemplate { get; set; } = new();

    public ActivityTemplate ActivityTemplate { get; set; } = new();

    public TimeSpan Duration { get; set; }
}
