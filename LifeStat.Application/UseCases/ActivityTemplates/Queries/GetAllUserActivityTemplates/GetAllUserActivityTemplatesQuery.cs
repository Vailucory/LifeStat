using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.ActivityTemplates.Queries.GetAllUserActivityTemplates;
public record GetAllUserActivityTemplatesQuery(int UserId) : IRequest<List<ActivityTemplate>>
{
}
