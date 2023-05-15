using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.CreateWeeklyPlanTemplate;
public record CreateWeeklyPlanTemplateCommand(
    int UserId,
    string Name,
    List<DailyPlanTemplate> DailyPlanTemplates) : ICommand
{
}
