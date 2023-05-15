using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.ActivityTemplates.Queries.GetActivityTemplate;
public record GetActivityTemplateQuery(int Id) : IQuery<ActivityTemplate>
{
}
