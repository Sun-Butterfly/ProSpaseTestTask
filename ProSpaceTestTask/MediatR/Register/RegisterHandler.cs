using FluentResults;
using MediatR;
using ProSpaceTestTask.Models;
using ProSpaceTestTask.Repositories;
using ProSpaceTestTask.Services;

namespace ProSpaceTestTask.MediatR.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IService _service;

    public RegisterHandler(IUserRepository userRepository, ICustomerRepository customerRepository, IService service)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
        _service = service;
    }

    public async Task<Result> Handle(RegisterRequest request, CancellationToken cancellationToken)
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
                Code = _service.GenerateCustomerCode()
            }
        };
        _userRepository.Add(user);
        await _userRepository.SaveChanges(cancellationToken);
        return Result.Ok();
    }
}