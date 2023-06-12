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

        var weeklyPlanTemplate = _context.WeeklyPlanTemplates.Where(wpt => wpt.Id == weeklyPlan.WeeklyPlanTemplate.Id).FirstOrDefault();

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

    public async Task<Result<WeeklyPlan>> GetByIdAsync(int id)
    {
        var weeklyPlan = _mapper.Map<WeeklyPlan>(await _context.WeeklyPlans
            .AsNoTracking()
            .FirstOrDefaultAsync(wp => wp.Id == id));

        if (weeklyPlan == null)
        {
            return Result<WeeklyPlan>.FromError(
                new EntityNotFoundError(typeof(WeeklyPlan), id));
        }

        return Result<WeeklyPlan>.Good(weeklyPlan);
    }

    public async Task<Result<WeeklyPlan>> GetByIdWithDailyPlansAsync(int id)
    {
        var weeklyPlan = _mapper.Map<WeeklyPlan>(await _context
            .WeeklyPlans
            .Include(wp => wp.WeeklyPlanTemplate)
            .Include(wp => wp.DailyPlans)
            .ThenInclude(dp => dp.Activities)
            .Include(wp => wp.DailyPlans)
            .ThenInclude(dp => dp.DailyPlanTemplate)
            .AsNoTracking()
            .FirstOrDefaultAsync(wp => wp.Id == id));

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

    public Result Remove(WeeklyPlan weeklyPlan)
    {
        _context.WeeklyPlans.Remove(_mapper.Map<WeeklyPlanDL>(weeklyPlan));

        return Result.Good();
    }

    public Result Update(WeeklyPlan weeklyPlan)
    {
        var entity = _context.WeeklyPlans.Find(weeklyPlan.Id);

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
