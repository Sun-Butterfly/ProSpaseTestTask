using FluentResults;
using MediatR;
using ProSpaceTestTask.Models;
using ProSpaceTestTask.Repositories;
using ProSpaceTestTask.Services;

namespace ProSpaceTestTask.MediatR.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IService _service;

    public RegisterHandler(IUserRepository userRepository, IService service)
    {
        _userRepository = userRepository;
        _service = service;
    }

    public async Task<Result> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByLogin(request.Login, cancellationToken);
        if (user != null)
        {
            return Result.Fail("Пользователь с таким логином уже существует!");
        }

        var role = await _userRepository.GetRoleByName("customer", cancellationToken);
        if (role == null)
        {
            return Result.Fail("Роль не найдена!");
        }
        
        user = new User()
        {
            Login = request.Login,
            Password = request.Password,
            Role = role,
            Customer = new Customer()
            {
                Name = request.Name,
                Address = request.Address,
                Code = _service.GenerateCustomerCode()
            }
        };
        _userRepository.Add(user);
        await _userRepository.SaveChanges(cancellationToken);
        return Result.Ok();
    }
}