using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Infrastructure.Persistence.Repositories;
public class WeeklyPlanRepository : IWeeklyPlanRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public WeeklyPlanRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Result Add(WeeklyPlan weeklyPlan, int userId)
    {
        var user = _context.InnerUsers
            .Where(u => u.Id == userId)
            .Include(u => u.DailyPlans)
            .FirstOrDefault();

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        var weeklyPlanTemplate = _context.WeeklyPlanTemplates
            .FirstOrDefault(wpt => wpt.Id == weeklyPlan.WeeklyPlanTemplate.Id && wpt.UserId == userId);

        if (weeklyPlanTemplate is null)
            return Result.FromError(new EntityNotFoundError(typeof(WeeklyPlanTemplate), weeklyPlan.WeeklyPlanTemplate.Id));

        var dailyPlans = user.DailyPlans.OrderBy(dp => dp.Id).TakeLast(7).Where(dp => dp.WeeklyPlanId is null).ToList();

        if (dailyPlans.Count < 7)
            return Result.FromError(new Error("Daily Plans", $"Weekly Plan require 7 Daily Plans instead of {dailyPlans.Count}."));

        WeeklyPlanDL weeklyPlanDL = _mapper.Map<WeeklyPlanDL>(weeklyPlan);

        weeklyPlanDL.DailyPlans = dailyPlans;

        weeklyPlanDL.WeeklyPlanTemplate = weeklyPlanTemplate;

        weeklyPlanDL.UserId = user.Id;

        user.WeeklyPlans.Add(weeklyPlanDL);

        return Result.Good();
    }

    public async Task<Result<WeeklyPlan>> GetByIdAsync(int id, int userId)
    {
        var weeklyPlan = _mapper.Map<WeeklyPlan>(await _context.WeeklyPlans
            .AsNoTracking()
            .FirstOrDefaultAsync(wp => wp.Id == id && wp.UserId == userId));

        if (weeklyPlan == null)
        {
            return Result<WeeklyPlan>.FromError(
                new EntityNotFoundError(typeof(WeeklyPlan), id));
        }

        return Result<WeeklyPlan>.Good(weeklyPlan);
    }

    public async Task<Result<WeeklyPlan>> GetByIdWithDailyPlansAsync(int id, int userId)
    {
        var weeklyPlan = _mapper.Map<WeeklyPlan>(await _context
            .WeeklyPlans
            .Include(wp => wp.WeeklyPlanTemplate)
            .Include(wp => wp.DailyPlans)
            .ThenInclude(dp => dp.Activities)
            .Include(wp => wp.DailyPlans)
            .ThenInclude(dp => dp.DailyPlanTemplate)
            .AsNoTracking()
            .FirstOrDefaultAsync(wp => wp.Id == id && wp.UserId == userId));

        if (weeklyPlan == null)
        {
            return Result<WeeklyPlan>.FromError(
                new EntityNotFoundError(typeof(WeeklyPlan), id));
        }

        return Result<WeeklyPlan>.Good(weeklyPlan);
    }

    public async Task<Result<List<WeeklyPlan>>> GetAllUserWeeklyPlansAsync(int userId)
    {
        return Result<List<WeeklyPlan>>.Good(
            _mapper.Map<List<WeeklyPlan>>(await _context
                .WeeklyPlans
                .Include(wp => wp.WeeklyPlanTemplate)
                .Include(wp => wp.DailyPlans)
                .ThenInclude(dp => dp.Activities)
                .Include(wp => wp.DailyPlans)
                .ThenInclude(dp => dp.DailyPlanTemplate)
                .Where(wp => wp.UserId == userId)
                .AsNoTracking()
                .ToListAsync()));
    }

    public Result Remove(WeeklyPlan weeklyPlan, int userId)
    {
        var weeklyPlanDL = _context.WeeklyPlans
            .FirstOrDefault(dpt => dpt.Id == weeklyPlan.Id && dpt.UserId == userId);

        if (weeklyPlanDL is null)
            return Result.FromError(
                new EntityNotFoundError(typeof(WeeklyPlan), weeklyPlan.Id));

        _context.WeeklyPlans.Remove(weeklyPlanDL);

        return Result.Good();
    }

    public Result Update(WeeklyPlan weeklyPlan, int userId)
    {
        var entity = _context.WeeklyPlans
            .FirstOrDefault(wp => wp.Id == weeklyPlan.Id && wp.UserId == userId);

        if (entity == null)
        {
            return Result.FromError(
                new EntityNotFoundError(typeof(WeeklyPlan), weeklyPlan.Id));
        }

        entity.FulfillmentStatus = weeklyPlan.FulfillmentStatus;

        entity.WeeklyPlanTemplateId = weeklyPlan.WeeklyPlanTemplate.Id;

        _context.WeeklyPlans.Update(entity);

        return Result.Good();
    }
}
