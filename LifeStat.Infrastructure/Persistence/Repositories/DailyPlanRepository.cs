using AutoMapper;
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

        user.DailyPlans
            .Add(_mapper.Map<DailyPlanDL>(dailyPlan));

        return Result.Good();
    }

    public async Task<Result<DailyPlan>> GetByIdAsync(int id)
    {
        var dailyPlan = _mapper.Map<DailyPlan>(await _context.DailyPlans
            .FindAsync(id));

        if (dailyPlan == null)
        {
            return Result<DailyPlan>.FromError(
                new EntityNotFoundError(typeof(DailyPlan), id));
        }

        return Result<DailyPlan>.Good(dailyPlan);
    }

    public async Task<Result<DailyPlan>> GetByIdWithActivitiesAsync(int id)
    {
        var dailyPlan = _mapper.Map<DailyPlan>(await _context.DailyPlans
            .Include(dp => dp.Activities)
            .FirstOrDefaultAsync(dp => dp.Id == id));

        if (dailyPlan == null)
        {
            return Result<DailyPlan>.FromError(
                new EntityNotFoundError(typeof(DailyPlan), id));
        }

        return Result<DailyPlan>.Good(dailyPlan);
    }

    public async Task<Result<List<DailyPlan>>> GetAllUserDailyPlansAsync(int userId)
    {
        return Result<List<DailyPlan>>.Good(
            _mapper.Map<List<DailyPlan>>(await _context
                .DailyPlans
                .Where(dp => dp.UserId == userId)
                .ToListAsync()));
    }

    public Result Remove(DailyPlan dailyPlan)
    {
        _context.DailyPlans.Remove(_mapper.Map<DailyPlanDL>(dailyPlan));

        return Result.Good();
    }

    public Result Update(DailyPlan dailyPlan)
    {
        var entity = _context.DailyPlans.Find(dailyPlan.Id);

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
