using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, Result<GetAllUsersResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<GetAllUsersResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll(cancellationToken);
        return Result.Ok(new GetAllUsersResponse(users));
    }
}