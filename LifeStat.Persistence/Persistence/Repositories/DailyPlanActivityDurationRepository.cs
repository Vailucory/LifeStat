using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Persistence.Models;

namespace LifeStat.Infrastructure.Persistence.Repositories;
public class DailyPlanActivityDurationRepository : IDailyPlanActivityDurationRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public DailyPlanActivityDurationRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Result Add(DailyPlanActivityDuration dailyPlanActivityDuration)
    {
        _context.DailyPlanActivityDurations
            .Add(_mapper
            .Map<DailyPlanActivityDurationDL>(dailyPlanActivityDuration));

        return Result.Good();
    }

    public Result AddRange(IEnumerable<DailyPlanActivityDuration> dailyPlanActivityDurations)
    {
        _context.DailyPlanActivityDurations
            .AddRange(_mapper
            .Map<IEnumerable<DailyPlanActivityDurationDL>>(dailyPlanActivityDurations));

        return Result.Good();
    }

    public async Task<Result<DailyPlanActivityDuration>> GetByIdAsync(int id)
    {
        var dailyPlanActivityDuration = _mapper.Map<DailyPlanActivityDuration>(await _context
            .DailyPlanActivityDurations
            .FindAsync(id));

        if (dailyPlanActivityDuration == null)
        {
            return Result<DailyPlanActivityDuration>.FromError(
                new EntityNotFoundError(typeof(DailyPlanActivityDuration), id));
        }

        return Result<DailyPlanActivityDuration>.Good(dailyPlanActivityDuration);
    }

    public Result Remove(DailyPlanActivityDuration dailyPlanActivityDuration)
    {
        _context.DailyPlanActivityDurations
            .Remove(_mapper
            .Map<DailyPlanActivityDurationDL>(dailyPlanActivityDuration));

        return Result.Good();
    }

    public Result Update(DailyPlanActivityDuration dailyPlanActivityDuration)
    {
        _context.DailyPlanActivityDurations
            .Update(_mapper
            .Map<DailyPlanActivityDurationDL>(dailyPlanActivityDuration));

        return Result.Good();
    }

}
