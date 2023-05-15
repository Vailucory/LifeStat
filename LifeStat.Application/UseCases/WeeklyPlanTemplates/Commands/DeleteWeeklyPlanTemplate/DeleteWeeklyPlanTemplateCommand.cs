using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.DeleteWeeklyPlanTemplate;
public record DeleteWeeklyPlanTemplateCommand(int Id) : ICommand
{
}
