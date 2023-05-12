using MediatR;

namespace LifeStat.Application.UseCases.Users.Commands.DeleteUser;
public record DeleteUserCommand(Guid Id) : IRequest<bool>
{
}
