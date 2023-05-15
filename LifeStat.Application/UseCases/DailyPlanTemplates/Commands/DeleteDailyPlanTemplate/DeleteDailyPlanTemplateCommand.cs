using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.DeleteDailyPlanTemplate;
public record DeleteDailyPlanTemplateCommand(int Id) : ICommand
{
}
