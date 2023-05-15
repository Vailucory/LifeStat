namespace LifeStat.Application.UseCases.Users.Queries;
public record UserViewModel(Guid Id, string UserName, string Email)
{
    public UserViewModel() : this(Guid.Empty, string.Empty, string.Empty)
    {
    }
}
