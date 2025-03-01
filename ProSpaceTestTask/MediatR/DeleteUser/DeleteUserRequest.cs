using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.DeleteUser;

public record DeleteUserRequest(string Id) : IRequest<Result>;