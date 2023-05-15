using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Activities.Queries.GetActivitiesByTemplateId;
public record GetActivitiesByTemplateIdQuery(int TemplateId) : IQuery<List<Activity>>
{
}
