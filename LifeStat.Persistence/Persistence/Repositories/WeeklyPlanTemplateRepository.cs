using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Exceptions;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Infrastructure.Persistence.Repositories;
internal class WeeklyPlanTemplateRepository : IWeeklyPlanTemplateRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public WeeklyPlanTemplateRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(WeeklyPlanTemplate weeklyPlanTemplate, int userId)
    {
        (_context.InnerUsers
            .FirstOrDefault(u => u.Id == userId)
            ?.WeeklyPlanTemplates
            ?? throw new EntityNotFoundException(userId, typeof(User)))
            .Add(_mapper.Map<WeeklyPlanTemplateDL>(weeklyPlanTemplate));
        ;
    }

    public async Task<WeeklyPlanTemplate> GetByIdAsync(int id)
    {
        return _mapper.Map<WeeklyPlanTemplate>(await _context.WeeklyPlanTemplates
            .FindAsync(id))
            ?? throw new EntityNotFoundException(id, typeof(WeeklyPlanTemplate));
    }

    public async Task<WeeklyPlanTemplate> GetByIdWithDailyPlanTemplatesAsync(int id)
    {
        return _mapper.Map<WeeklyPlanTemplate>(await _context
            .WeeklyPlanTemplates
            .Include(wpt => wpt.DailyPlansTemplates)
            .FirstOrDefaultAsync(wpt => wpt.Id == id))
            ?? throw new EntityNotFoundException(id, typeof(WeeklyPlanTemplate));
    }


    public async Task<List<WeeklyPlanTemplate>> GetAllUserWeeklyPlanTemplatesAsync(int userId)
    {
        return _mapper.Map<List<WeeklyPlanTemplate>>(await _context
            .WeeklyPlanTemplates
            .Where(wpt => wpt.UserId == userId)
            .ToListAsync());
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
