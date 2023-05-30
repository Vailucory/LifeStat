using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Activities;
public record GetAllUserActivitiesQuery(int UserId) : IQuery<List<Activity>>
{
}
