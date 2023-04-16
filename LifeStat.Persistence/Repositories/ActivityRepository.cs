using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Persistence.Models;

namespace LifeStat.Persistence.Repositories;
public class ActivityRepository : IActivityRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public ActivityRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(Activity activity)
    {
        _context.Activities.Add(_mapper.Map<ActivityDL>(activity));
    }

    public async Task<Activity> GetByIdAsync(int id)
    {
        return _mapper.Map<Activity>(await _context.Activities.FindAsync(id));
    }

    public void Remove(Activity activity)
    {
        _context.Activities.Remove(_mapper.Map<ActivityDL>(activity));
    }

    public void Update(Activity activity)
    {
        _context.Activities.Update(_mapper.Map<ActivityDL>(activity));
    }
}
