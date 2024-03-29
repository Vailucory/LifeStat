﻿using Domain.Enums;

namespace LifeStat.Infrastructure.Persistence.Models;

public class WeeklyPlanDL
{
    public int Id { get; set; }

    public WeeklyPlanTemplateDL WeeklyPlanTemplate { get; set; } 

    public List<DailyPlanDL> DailyPlans { get; set; } = new();

    public PlanFulfillmentStatus FulfillmentStatus { get; set; }

    #region Navigation Properties
    public UserDL? User { get; set; } 

    public int? UserId { get; set; }

    public int WeeklyPlanTemplateId { get; set; }

    #endregion
}
