using LifeStat.Domain.Shared;

namespace LifeStat.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    public Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default);
}
