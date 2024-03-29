﻿using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public record GetActivityTemplateQuery(int Id, int UserId) : IQuery<ActivityTemplate>
{
}
