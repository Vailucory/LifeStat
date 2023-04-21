using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.Activities.Queries.GetActivitiesByTemplateId;
public record GetActivitiesByTemplateIdQuery(int TemplateId) : IRequest<List<Activity>>
{
}
