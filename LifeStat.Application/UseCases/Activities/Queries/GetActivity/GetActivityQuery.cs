using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Activities.Queries.GetActivity;
public record GetActivityQuery(int Id) : IQuery<Activity>
{
}
