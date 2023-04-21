using Domain.Models;
using MediatR;

namespace LifeStat.Application.UseCases.Activities.Queries.GetActivity;
public record GetActivityQuery(int Id) : IRequest<Activity>
{
}
