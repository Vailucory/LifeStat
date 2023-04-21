using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.UpdateWeeklyPlanTemplate;
public record UpdateWeeklyPlanTemplateCommand(WeeklyPlanTemplate WeeklyPlanTemplate) : IRequest
{
}
