using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Queries.GetAllUserDailyPlanTemplates;
public record GetAllUserDailyPlanTemplatesQuery(int UserId) : IRequest<List<DailyPlanTemplate>>
{
}
