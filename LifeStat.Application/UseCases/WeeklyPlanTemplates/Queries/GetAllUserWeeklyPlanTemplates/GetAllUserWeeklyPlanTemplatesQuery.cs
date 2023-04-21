using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Queries.GetAllUserWeeklyPlanTemplates;
public record GetAllUserWeeklyPlanTemplatesQuery(int UserId) : IRequest<List<WeeklyPlanTemplate>>
{
}
