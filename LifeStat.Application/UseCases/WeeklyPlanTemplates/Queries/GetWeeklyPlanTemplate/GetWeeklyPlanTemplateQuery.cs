﻿using Domain.Models;
using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public record GetWeeklyPlanTemplateQuery(int Id, int UserId) : IQuery<WeeklyPlanTemplate>
{
}
