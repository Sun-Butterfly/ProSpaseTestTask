using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.Register;

public record RegisterRequest(
    string Login,
    string Password,
    string Name,
    string Address
) : IRequest<Result>;