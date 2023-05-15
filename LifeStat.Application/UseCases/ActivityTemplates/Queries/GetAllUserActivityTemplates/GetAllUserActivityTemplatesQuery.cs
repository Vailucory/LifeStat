using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.ActivityTemplates.Queries.GetAllUserActivityTemplates;
public record GetAllUserActivityTemplatesQuery(int UserId) : IQuery<List<ActivityTemplate>>
{
}
