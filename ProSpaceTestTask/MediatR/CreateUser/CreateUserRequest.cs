using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.CreateUser;

public record CreateUserRequest(
    string Login,
    string Password,
    string Name,
    string Address,
    int Discount,
    string RoleName
    ) : IRequest<Result>;