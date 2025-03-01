using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.GetUserById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, Result<GetUserByIdResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<GetUserByIdResponse>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdDto(request.Id, cancellationToken);

        return Result.Ok(new GetUserByIdResponse(user));
    }
}