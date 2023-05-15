using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.CreateDailyPlanTemplate;
public record CreateDailyPlanTemplateCommand(
    int UserId, 
    string Name, 
    List<DailyPlanActivityDuration> ActivityDurations) : ICommand
{
}
