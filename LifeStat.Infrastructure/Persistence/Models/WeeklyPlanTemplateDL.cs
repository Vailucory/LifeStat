﻿namespace LifeStat.Infrastructure.Persistence.Models;

public class WeeklyPlanTemplateDL
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<WeeklyPlanTemplateDayDL> WeeklyPlanTemplateDays { get; set; } = new();


    #region Navigation Properties
    public UserDL User { get; set; }

    public int UserId { get; set; }

    public List<WeeklyPlanDL> WeeklyPlans { get; set; } = new();

    #endregion
}
