using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.ActivityTemplates.Queries.GetActivityTemplate;
public record GetActivityTemplateQuery(int Id) : IRequest<ActivityTemplate>
{
}
