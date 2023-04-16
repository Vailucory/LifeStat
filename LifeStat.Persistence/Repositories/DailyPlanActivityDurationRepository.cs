using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Persistence.Models;

namespace LifeStat.Persistence.Repositories;
public class DailyPlanActivityDurationRepository : IDailyPlanActivityDurationRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public DailyPlanActivityDurationRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(DailyPlanActivityDuration dailyPlanActivityDuration)
    {
        _context.DailyPlanActivityDurations
            .Add(_mapper
            .Map<DailyPlanActivityDurationDL>(dailyPlanActivityDuration));
    }

    public void AddRange(IEnumerable<DailyPlanActivityDuration> dailyPlanActivityDurations)
    {
        _context.DailyPlanActivityDurations
            .AddRange(_mapper
            .Map<IEnumerable<DailyPlanActivityDurationDL>>(dailyPlanActivityDurations));
    }

    public async Task<DailyPlanActivityDuration> GetByIdAsync(int id)
    {
        return _mapper.Map<DailyPlanActivityDuration>(await _context
            .DailyPlanActivityDurations
            .FindAsync(id));
    }

    public void Remove(DailyPlanActivityDuration dailyPlanActivityDuration)
    {
        _context.DailyPlanActivityDurations
            .Remove(_mapper
            .Map<DailyPlanActivityDurationDL>(dailyPlanActivityDuration));
    }

    public void Update(DailyPlanActivityDuration dailyPlanActivityDuration)
    {
        _context.DailyPlanActivityDurations
            .Update(_mapper
            .Map<DailyPlanActivityDurationDL>(dailyPlanActivityDuration));
    }

}
