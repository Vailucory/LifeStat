using LifeStat.Domain.Shared;

namespace LifeStat.Infrastructure.Identity;
public interface ICurrentUserIdProvider
{
    Result<int> GetId(string userSid);
}
