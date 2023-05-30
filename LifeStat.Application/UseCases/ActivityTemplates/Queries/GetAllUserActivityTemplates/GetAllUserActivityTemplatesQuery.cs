using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public record GetAllUserActivityTemplatesQuery(int UserId) : IQuery<List<ActivityTemplate>>
{
}
