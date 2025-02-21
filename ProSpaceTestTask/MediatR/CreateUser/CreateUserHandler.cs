using FluentResults;
using MediatR;
using ProSpaceTestTask.Models;
using ProSpaceTestTask.Repositories;
using ProSpaceTestTask.Services;

namespace ProSpaceTestTask.MediatR.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IService _service;

    public CreateUserHandler(IUserRepository userRepository, IService service)
    {
        _userRepository = userRepository;
        _service = service;
    }

    public async Task<Result> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByLogin(request.Login, cancellationToken);
        if (user != null)
        {
            return Result.Fail("Пользователь с таким логином уже существует!");
        }
        
        user = new User()
        {
            Login = request.Login,
            Password = request.Password,
            RoleId = _service.GetRoleId(),
            Customer = new Customer()
            {
                Name = request.Name,
                Address = request.Address,
                Code = _service.GenerateCustomerCode(),
                Discount = request.Discount
            }
        };
        _userRepository.Add(user);
        await _userRepository.SaveChanges(cancellationToken);
        return Result.Ok();
    }
}