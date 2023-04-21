using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.CreateWeeklyPlanTemplate;
public record CreateWeeklyPlanTemplateCommand(
    int UserId,
    string Name,
    List<DailyPlanTemplate> DailyPlanTemplates) : IRequest
{
}
