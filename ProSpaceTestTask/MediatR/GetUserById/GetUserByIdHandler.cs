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
        var idGuid = Guid.Parse(request.Id);
        var user = await _userRepository.GetByIdDto(idGuid, cancellationToken);

        return Result.Ok(new GetUserByIdResponse(user));
    }
}