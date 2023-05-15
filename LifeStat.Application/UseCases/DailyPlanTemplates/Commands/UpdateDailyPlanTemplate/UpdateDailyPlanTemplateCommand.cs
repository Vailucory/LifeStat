using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.UpdateDailyPlanTemplate;
public record UpdateDailyPlanTemplateCommand(DailyPlanTemplate DailyPlanTemplate) : ICommand
{
}
