using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Exceptions;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Persistence.Repositories;
public class WeeklyPlanRepository : IWeeklyPlanRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public WeeklyPlanRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(WeeklyPlan weeklyPlan, int userId)
    {
        var user = _context.Users.Include(u => u.DailyPlans).FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            throw new EntityNotFoundException(userId, typeof(User));
        }

        var dailyPlans =  user.DailyPlans.OrderBy(dp => dp.Id).ToList();
        if (dailyPlans.Count > 7)
        {
            dailyPlans = dailyPlans.TakeLast(7).ToList();
        }

        weeklyPlan.DailyPlans = _mapper.Map<List<DailyPlan>>(dailyPlans) ;

        user?.WeeklyPlans.Add(_mapper.Map<WeeklyPlanDL>(weeklyPlan));
    }

    public async Task<WeeklyPlan> GetByIdAsync(int id)
    {
        return _mapper.Map<WeeklyPlan>(await _context.WeeklyPlans
            .FindAsync(id))
            ?? throw new EntityNotFoundException(id, typeof(WeeklyPlan));
    }

    public async Task<WeeklyPlan> GetByIdWithDailyPlansAsync(int id)
    {
        return _mapper.Map<WeeklyPlan>(await _context
            .WeeklyPlans
            .Include(wp => wp.DailyPlans)
            .FirstOrDefaultAsync(wp => wp.Id == id))
            ?? throw new EntityNotFoundException(id, typeof(WeeklyPlan));
    }

    public async Task<List<WeeklyPlan>> GetAllUserWeeklyPlansAsync(int userId)
    {
        return _mapper.Map<List<WeeklyPlan>>(await _context
            .WeeklyPlans
            .Where(wp => wp.UserId == userId)
            .ToListAsync());
    }

    public void Remove(WeeklyPlan weeklyPlan)
    {
        _context.WeeklyPlans.Remove(_mapper.Map<WeeklyPlanDL>(weeklyPlan));
    }

    public void Update(WeeklyPlan weeklyPlan)
    {
        _context.WeeklyPlans.Update(_mapper.Map<WeeklyPlanDL>(weeklyPlan));
    }
}
