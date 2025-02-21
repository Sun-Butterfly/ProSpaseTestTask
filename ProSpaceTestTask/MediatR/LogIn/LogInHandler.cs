using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentResults;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.LogIn;

public class LogInHandler : IRequestHandler<LogInRequest, Result<LogInResponse>>
{
    private readonly IUserRepository _userRepository;

    public LogInHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<LogInResponse>> Handle(LogInRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByLoginAndPassword(request.Login, request.Password, cancellationToken);
        if (user is null)
        {
            return Result.Fail("Неверный логин или пароль");
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKeyforProSpaseTestTask@345"));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new Claim(type: "Login", value: user.Login),
            new Claim(type: ClaimTypes.Name, value: user.Customer?.Name ?? "admin"),
            new Claim(type: ClaimTypes.Role, value: user.Role.Name),
            new Claim(type: "Id", value: user.Id.ToString())
        };
        var tokenOptions = new JwtSecurityToken(
            issuer: "https://localhost:5284",
            audience: "https://localhost:5284",
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: signingCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return Result.Ok(new LogInResponse(tokenString));
    }
}