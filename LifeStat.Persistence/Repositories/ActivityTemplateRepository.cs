using AutoMapper;
using Domain.Models;
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

    public void Add(ActivityTemplate activityTemplate)
    {
        _context.ActivityTemplates.Add(_mapper.Map<ActivityTemplateDL>(activityTemplate));
    }

    public async Task<ActivityTemplate> GetByIdAsync(int id)
    {
        return _mapper.Map<ActivityTemplate>(await _context
            .ActivityTemplates
            .FindAsync(id));
    }

    public async Task<ActivityTemplate> GetByIdWithActivitiesAsync(int id)
    {
        return _mapper.Map<ActivityTemplate>(await _context
            .ActivityTemplates
            .Include(at => at.Activities)
            .FirstOrDefaultAsync(at => at.Id == id));
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
