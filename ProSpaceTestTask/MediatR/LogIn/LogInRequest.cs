using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.LogIn;

public record LogInRequest(
    string Login,
    string Password
) : IRequest<Result<LogInResponse>>;