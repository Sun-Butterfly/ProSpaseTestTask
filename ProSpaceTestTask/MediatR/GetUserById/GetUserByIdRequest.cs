using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.GetUserById;

public record GetUserByIdRequest(string Id) : IRequest<Result<GetUserByIdResponse>>;