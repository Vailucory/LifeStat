using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace LifeStat.Infrastructure.Identity;
public class ApplicationUser : IdentityUser<Guid>
{
    public UserDL InnerUser { get; set; } = new();
}
