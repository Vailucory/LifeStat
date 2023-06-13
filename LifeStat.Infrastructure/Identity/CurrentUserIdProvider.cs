using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Infrastructure.Identity;
public class CurrentUserIdProvider : ICurrentUserIdProvider
{
    private readonly ApplicationDbContext _context;

    public CurrentUserIdProvider(ApplicationDbContext context)
    {
        _context = context;
    }

    public Result<int> GetId(string userSid)
    {
        var appuser = _context.Users.Include(u => u.InnerUser).FirstOrDefault(u => u.Id.ToString() == userSid);

        if (appuser is null)    
            return Result<int>.FromError(new Error(
                nameof(userSid),
                "User not found by provided Sid"));

        var id = appuser.InnerUser.Id;

        return Result<int>.Good(id);
    }
}
