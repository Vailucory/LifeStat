using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Persistence.Repositories;
public class DailyPlanRepository : IDailyPlanRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public DailyPlanRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(DailyPlan dailyPlan)
    {
        _context.DailyPlans.Add(_mapper.Map<DailyPlanDL>(dailyPlan));
    }

    public async Task<DailyPlan> GetByIdAsync(int id)
    {
        return _mapper.Map<DailyPlan>(await _context.DailyPlans.FindAsync(id));
    }

    public async Task<DailyPlan> GetByIdWithActivitiesAsync(int id)
    {
        return _mapper.Map<DailyPlan>(await _context
            .DailyPlans
            .Include(dp => dp.Activities)
            .FirstOrDefaultAsync(dp => dp.Id == id));
    }

    public void Remove(DailyPlan dailyPlan)
    {
        _context.DailyPlans.Remove(_mapper.Map<DailyPlanDL>(dailyPlan));
    }

    public void Update(DailyPlan dailyPlan)
    {
        _context.DailyPlans.Update(_mapper.Map<DailyPlanDL>(dailyPlan));
    }
}
