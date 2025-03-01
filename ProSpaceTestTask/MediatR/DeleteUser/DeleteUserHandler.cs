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
        var idGuid = Guid.Parse(request.Id);
        var user = await _userRepository.GetById(idGuid, cancellationToken);
        if (user == null)
        {
            return Result.Fail("Пользователь не найден!");
        }

        await _userRepository.Delete(user, cancellationToken);
        return Result.Ok();
    }
}