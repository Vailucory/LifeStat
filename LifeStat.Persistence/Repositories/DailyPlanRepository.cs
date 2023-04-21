using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Exceptions;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

    public void Add(DailyPlan dailyPlan, int userId)
    {
        (_context.Users
            .FirstOrDefault(u => u.Id == userId)
            ?.DailyPlans
            ?? throw new EntityNotFoundException(userId, typeof(User)))
            .Add(_mapper.Map<DailyPlanDL>(dailyPlan));
    }

    public async Task<DailyPlan> GetByIdAsync(int id)
    {
        return _mapper.Map<DailyPlan>(await _context.DailyPlans
            .FindAsync(id))
            ?? throw new EntityNotFoundException(id, typeof(DailyPlan));
    }

    public async Task<DailyPlan> GetByIdWithActivitiesAsync(int id)
    {
        return _mapper.Map<DailyPlan>(await _context
            .DailyPlans
            .Include(dp => dp.Activities)
            .FirstOrDefaultAsync(dp => dp.Id == id))
            ?? throw new EntityNotFoundException(id, typeof(DailyPlan));
    }

    public async Task<List<DailyPlan>> GetAllUserDailyPlansAsync(int userId)
    {
        return _mapper.Map<List<DailyPlan>>(await _context
            .DailyPlans
            .Where(dp => dp.UserId == userId)
            .ToListAsync());
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
