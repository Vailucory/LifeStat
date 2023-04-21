using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.Activities.Queries.GetAllUserActivities;
public record GetAllUserActivitiesQuery(int UserId) : IRequest<List<Activity>>
{
}
