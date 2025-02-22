using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.DeleteUser;

public record DeleteUserRequest(Guid Id) : IRequest<Result>;