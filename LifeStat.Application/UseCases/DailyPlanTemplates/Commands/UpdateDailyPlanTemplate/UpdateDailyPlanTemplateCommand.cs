using LifeStat.Application.Interfaces;
using LifeStat.Domain.ViewModels;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public record UpdateDailyPlanTemplateCommand(int DailyPlanTemplateId, string DailyPlanTemplateName, List<DailyPlanActivityDurationViewModel> Activities, int UserId) : ICommand
{
}
