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
        var user = _context.InnerUsers.Find(userId);

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        var dailyPlans = user.DailyPlans.OrderBy(dp => dp.Id).ToList();
        if (dailyPlans.Count > 7)
        {
            dailyPlans = dailyPlans.TakeLast(7).ToList();
        }

        weeklyPlan.DailyPlans = _mapper.Map<List<DailyPlan>>(dailyPlans);

        user.WeeklyPlans.Add(_mapper.Map<WeeklyPlanDL>(weeklyPlan));

        return Result.Good();
    }

    public async Task<Result<WeeklyPlan>> GetByIdAsync(int id)
    {
        var weeklyPlan = _mapper.Map<WeeklyPlan>(await _context.WeeklyPlans
            .FindAsync(id));

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
            .Include(wp => wp.DailyPlans)
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
                .Where(wp => wp.UserId == userId)
                .ToListAsync()));
    }

    public Result Remove(WeeklyPlan weeklyPlan)
    {
        _context.WeeklyPlans.Remove(_mapper.Map<WeeklyPlanDL>(weeklyPlan));

        return Result.Good();
    }

    public Result Update(WeeklyPlan weeklyPlan)
    {
        _context.WeeklyPlans.Update(_mapper.Map<WeeklyPlanDL>(weeklyPlan));

        return Result.Good();
    }
}
