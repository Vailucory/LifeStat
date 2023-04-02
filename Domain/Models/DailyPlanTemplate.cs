namespace Domain.Models;
public class DailyPlanTemplate
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<DailyPlanActivityDuration> Activities { get; set; } = new();
}
