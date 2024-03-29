﻿using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Infrastructure.Persistence.Repositories;
public class DailyPlanRepository : IDailyPlanRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public DailyPlanRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public Result Add(DailyPlan dailyPlan, int userId)
    {
        var user = _context.InnerUsers.Find(userId);

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        var template = _context.DailyPlanTemplates
            .FirstOrDefault(dp => dp.Id == dailyPlan.DailyPlanTemplate.Id && dp.UserId == userId);

        if (template is null)
            return Result.FromError(new EntityNotFoundError(typeof(DailyPlanTemplate), dailyPlan.DailyPlanTemplate.Id));

        var activityIds = dailyPlan.Activities.Select(a => a.Id).ToList();

        var activities = _context.Activities.Where(a => activityIds.Contains(a.Id)).ToList();

        var dailyPlanDL = _mapper.Map<DailyPlanDL>(dailyPlan);

        dailyPlanDL.DailyPlanTemplate = template;

        dailyPlanDL.Activities = activities;

        dailyPlanDL.UserId = user.Id;

        user.DailyPlans.Add(dailyPlanDL);

        return Result.Good();
    }

    public async Task<Result<DailyPlan>> GetByIdAsync(int id, int userId)
    {
        var dailyPlan = _mapper.Map<DailyPlan>(await _context.DailyPlans
            .Include(dp => dp.DailyPlanTemplate)
            .AsNoTracking()
            .FirstOrDefaultAsync(dp => dp.Id == id && dp.UserId == userId));

        if (dailyPlan == null)
        {
            return Result<DailyPlan>.FromError(
                new EntityNotFoundError(typeof(DailyPlan), id));
        }

        return Result<DailyPlan>.Good(dailyPlan);
    }

    public async Task<Result<DailyPlan>> GetByIdWithActivitiesAsync(int id, int userId)
    {
        var dailyPlanDL = await _context.DailyPlans
            .Include(dp => dp.Activities)
            .Include(dp => dp.DailyPlanTemplate)
            .AsNoTracking()
            .FirstOrDefaultAsync(dp => dp.Id == id && dp.UserId == userId);

        if (dailyPlanDL == null)
        {
            return Result<DailyPlan>.FromError(
                new EntityNotFoundError(typeof(DailyPlan), id));
        }

        var dailyPlan = _mapper.Map<DailyPlan>(dailyPlanDL);

        return Result<DailyPlan>.Good(dailyPlan);
    }

    public async Task<Result<List<DailyPlan>>> GetAllUserDailyPlansAsync(int userId)
    {
        return Result<List<DailyPlan>>.Good(
            _mapper.Map<List<DailyPlan>>(await _context
                .DailyPlans
                .Include(dp => dp.DailyPlanTemplate)
                .Where(dp => dp.UserId == userId)
                .AsNoTracking()
                .ToListAsync()));
    }

    public Result Remove(DailyPlan dailyPlan, int userId)
    {
        var dailyPlanDL = _context.DailyPlans
            .FirstOrDefault(dp => dp.Id == dailyPlan.Id && dp.UserId == userId);

        if (dailyPlanDL is null)
            return Result.FromError(
                new EntityNotFoundError(typeof(DailyPlan), dailyPlan.Id));

        _context.DailyPlans.Remove(dailyPlanDL);

        return Result.Good();
    }

    public Result Update(DailyPlan dailyPlan, int userId)
    {
        var entity = _context.DailyPlans
            .FirstOrDefault(dp => dp.Id == dailyPlan.Id && dp.UserId == userId);

        if (entity == null)
        {
            return Result.FromError(
                new EntityNotFoundError(typeof(DailyPlan), dailyPlan.Id));
        }

        entity.DailyPlanTemplateId = dailyPlan.DailyPlanTemplate.Id;

        entity.FulfillmentStatus = dailyPlan.FulfillmentStatus;

        _context.DailyPlans.Update(entity);

        return Result.Good();
    }
}
