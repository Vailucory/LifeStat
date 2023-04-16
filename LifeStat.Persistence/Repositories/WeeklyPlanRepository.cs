using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Persistence.Repositories;
internal class WeeklyPlanRepository : IWeeklyPlanRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public WeeklyPlanRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(WeeklyPlan weeklyPlan)
    {
        _context.WeeklyPlans.Add(_mapper.Map<WeeklyPlanDL>(weeklyPlan));
    }

    public async Task<WeeklyPlan> GetByIdAsync(int id)
    {
        return _mapper.Map<WeeklyPlan>(await _context.WeeklyPlans.FindAsync(id));
    }

    public async Task<WeeklyPlan> GetByIdWithDailyPlansAsync(int id)
    {
        return _mapper.Map<WeeklyPlan>(await _context
            .WeeklyPlans
            .Include(wp => wp.DailyPlans)
            .FirstOrDefaultAsync(wp => wp.Id == id));
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
