namespace LifeStat.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
