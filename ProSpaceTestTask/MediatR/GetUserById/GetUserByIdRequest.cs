using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.GetUserById;

public record GetUserByIdRequest(Guid Id) : IRequest<Result<GetUserByIdResponse>>;