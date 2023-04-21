using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.UpdateDailyPlanTemplate;
public record UpdateDailyPlanTemplateCommand(DailyPlanTemplate DailyPlanTemplate) : IRequest
{
}
