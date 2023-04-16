using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Persistence.Repositories;
public class DailyPlanTemplateRepository : IDailyPlanTemplateRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public DailyPlanTemplateRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(DailyPlanTemplate dailyPlanTemplate)
    {
        _context.DailyPlanTemplates.Add(_mapper.Map<DailyPlanTemplateDL>(dailyPlanTemplate));
    }

    public async Task<DailyPlanTemplate> GetByIdAsync(int id)
    {
        return _mapper.Map<DailyPlanTemplate>(await _context.DailyPlanTemplates.FindAsync(id));
    }

    public async Task<DailyPlanTemplate> GetByIdWithActivityDurationsAsync(int id)
    {
        return _mapper.Map<DailyPlanTemplate>(await _context
            .DailyPlanTemplates
            .Include(dpt => dpt.Activities)
            .FirstOrDefaultAsync(dpt => dpt.Id == id));
    }

    public async Task<DailyPlanTemplate> GetByIdWithDailyPlansAsync(int id)
    {
        return _mapper.Map<DailyPlanTemplate>(await _context
            .DailyPlanTemplates
            .Include(dpt => dpt.DailyPlans)
            .FirstOrDefaultAsync(dpt => dpt.Id == id));
    }

    public void Remove(DailyPlanTemplate dailyPlanTemplate)
    {
        _context.DailyPlanTemplates.Remove(_mapper.Map<DailyPlanTemplateDL>(dailyPlanTemplate));
    }

    public void Update(DailyPlanTemplate dailyPlanTemplate)
    {
        _context.DailyPlanTemplates.Update(_mapper.Map<DailyPlanTemplateDL>(dailyPlanTemplate));
    }
}
