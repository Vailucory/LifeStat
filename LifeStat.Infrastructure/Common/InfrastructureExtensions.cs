using LifeStat.Domain.Shared.Errors;
using Microsoft.AspNetCore.Identity;

namespace LifeStat.Infrastructure.Common;
public static class InfrastructureExtensions
{
    public static IEnumerable<Error> ExtractErrors(this IdentityResult identityResult)
    {
        return identityResult.Errors.Select(ie => new Error(ie.Code, ie.Description));
    }
}