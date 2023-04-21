using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.DeleteWeeklyPlanTemplate;
public record DeleteWeeklyPlanTemplateCommand(int Id) : IRequest
{
}
