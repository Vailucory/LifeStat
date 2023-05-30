using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public record DeleteWeeklyPlanTemplateCommand(int Id) : ICommand
{
}
