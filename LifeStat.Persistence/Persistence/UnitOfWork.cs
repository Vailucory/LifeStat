using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;

namespace LifeStat.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Good();
        }
        catch (Exception e)
        {
            return Result.FromError(Error.FromException(e));
        }
    }
}
