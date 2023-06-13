using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Activities;
public record GetActivityQuery(int Id, int UserId) : IQuery<Activity>
{
}
