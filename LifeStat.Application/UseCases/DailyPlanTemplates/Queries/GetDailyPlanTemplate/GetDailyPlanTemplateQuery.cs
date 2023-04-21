using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Queries.GetDailyPlanTemplate;
public record GetDailyPlanTemplateQuery(int Id) : IRequest<DailyPlanTemplate>
{
}
