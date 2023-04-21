using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.CreateDailyPlanTemplate;
public record CreateDailyPlanTemplateCommand(
    int UserId, 
    string Name, 
    List<DailyPlanActivityDuration> ActivityDurations) : IRequest
{
}
