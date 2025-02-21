using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.RedactUser;

public record RedactUserRequest(
    Guid Id,
    string Login,
    string Password,
    string Name,
    string Address,
    string Code,
    int Discount,
    string RoleName
) : IRequest<Result>;