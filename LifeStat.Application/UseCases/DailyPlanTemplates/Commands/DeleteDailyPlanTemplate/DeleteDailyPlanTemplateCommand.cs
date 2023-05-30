using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public record DeleteDailyPlanTemplateCommand(int Id) : ICommand
{
}
