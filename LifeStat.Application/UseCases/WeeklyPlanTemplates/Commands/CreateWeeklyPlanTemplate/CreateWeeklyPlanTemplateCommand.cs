using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public record CreateWeeklyPlanTemplateCommand(
    int UserId,
    string Name,
    List<DailyPlanTemplate> DailyPlanTemplates) : ICommand
{
}
