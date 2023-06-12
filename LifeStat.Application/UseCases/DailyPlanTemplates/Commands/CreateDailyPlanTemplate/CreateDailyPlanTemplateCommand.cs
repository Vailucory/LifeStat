using LifeStat.Application.Interfaces;
using LifeStat.Domain.ViewModels;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public record CreateDailyPlanTemplateCommand(
    int UserId, 
    string Name, 
    List<DailyPlanActivityDurationViewModel> ActivityDurations) : ICommand
{
}
