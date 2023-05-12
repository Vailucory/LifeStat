using MediatR;

namespace LifeStat.Application.UseCases.Users.Commands.ChangeUserName;
public record ChangeUserNameCommand(Guid UserId, string NewUserName) : IRequest<bool>
{
}
