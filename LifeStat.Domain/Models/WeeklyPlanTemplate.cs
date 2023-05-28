namespace Domain.Models;
public class WeeklyPlanTemplate
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<DailyPlanTemplate> DailyPlansTemplates { get; set; } = new();
}
