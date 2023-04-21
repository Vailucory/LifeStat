using MediatR;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.DeleteDailyPlanTemplate;
public record DeleteDailyPlanTemplateCommand(int Id) : IRequest
{
}
