using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Result>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id, cancellationToken);
        if (user == null)
        {
            return Result.Fail("Пользователь не найден!");
        }

        await _userRepository.Delete(user, cancellationToken);
        return Result.Ok();
    }
}