using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Activities;
public record GetActivitiesByTemplateIdQuery(int TemplateId, int UserId) : IQuery<List<Activity>>
{
}
