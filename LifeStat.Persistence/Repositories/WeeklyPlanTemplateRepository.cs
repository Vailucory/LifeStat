using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Persistence.Repositories;
internal class WeeklyPlanTemplateRepository : IWeeklyPlanTemplateRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public WeeklyPlanTemplateRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(WeeklyPlanTemplate weeklyPlanTemplate)
    {
        _context.WeeklyPlanTemplates.Add(_mapper.Map<WeeklyPlanTemplateDL>(weeklyPlanTemplate));
    }

    public async Task<WeeklyPlanTemplate> GetByIdAsync(int id)
    {
        return _mapper.Map<WeeklyPlanTemplate>(await _context.WeeklyPlanTemplates.FindAsync(id));
    }

    public async Task<WeeklyPlanTemplate> GetByIdWithDailyPlanTemplatesAsync(int id)
    {
        return _mapper.Map<WeeklyPlanTemplate>(await _context
            .WeeklyPlanTemplates
            .Include(wpt => wpt.DailyPlansTemplates)
            .FirstOrDefaultAsync(wpt => wpt.Id == id));
    }

    public void Remove(WeeklyPlanTemplate weeklyPlanTemplate)
    {
        _context.WeeklyPlanTemplates.Remove(_mapper.Map<WeeklyPlanTemplateDL>(weeklyPlanTemplate));
    }

    public void Update(WeeklyPlanTemplate weeklyPlanTemplate)
    {
        _context.WeeklyPlanTemplates.Update(_mapper.Map<WeeklyPlanTemplateDL>(weeklyPlanTemplate));
    }
}
