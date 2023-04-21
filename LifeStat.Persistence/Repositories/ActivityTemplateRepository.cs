using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Exceptions;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Persistence.Repositories;
public class ActivityTemplateRepository : IActivityTemplateRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public ActivityTemplateRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(ActivityTemplate activityTemplate, int userId)
    {
        (_context.Users
            .FirstOrDefault(u => u.Id == userId)
            ?.ActivityTemplates
            ?? throw new EntityNotFoundException(userId, typeof(User)))
            .Add(_mapper.Map<ActivityTemplateDL>(activityTemplate));
    }

    public async Task<ActivityTemplate> GetByIdAsync(int id)
    {
        return _mapper.Map<ActivityTemplate>(await _context
            .ActivityTemplates
            .FindAsync(id))
            ?? throw new EntityNotFoundException(id, typeof(ActivityTemplate));
    }

    public async Task<ActivityTemplate> GetByIdWithActivitiesAsync(int id)
    {
        return _mapper.Map<ActivityTemplate>(await _context
            .ActivityTemplates
            .Include(at => at.Activities)
            .FirstOrDefaultAsync(at => at.Id == id))
            ?? throw new EntityNotFoundException(id, typeof(ActivityTemplate));
    }

    public async Task<List<ActivityTemplate>> GetAllUserActivityTemplatesAsync(int userId)
    {
        return _mapper.Map<List<ActivityTemplate>>(await _context
            .ActivityTemplates
            .Where(at => at.UserId == userId)
            .ToListAsync());
    }

    public void Remove(ActivityTemplate activityTemplate)
    {
        _context.ActivityTemplates.Remove(_mapper.Map<ActivityTemplateDL>(activityTemplate));
    }

    public void Update(ActivityTemplate activityTemplate)
    {
        _context.ActivityTemplates.Update(_mapper.Map<ActivityTemplateDL>(activityTemplate));
    }
}
