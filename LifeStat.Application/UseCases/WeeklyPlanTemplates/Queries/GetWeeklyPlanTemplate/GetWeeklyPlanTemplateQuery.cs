using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Queries.GetWeeklyPlanTemplate;
public record GetWeeklyPlanTemplateQuery(int Id) : IRequest<WeeklyPlanTemplate>
{
}
