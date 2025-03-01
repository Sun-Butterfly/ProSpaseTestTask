using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.GetAllUsers;

public record GetAllUsersRequest() : IRequest<Result<GetAllUsersResponse>>;