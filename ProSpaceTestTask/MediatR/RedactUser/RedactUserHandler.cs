using FluentResults;
using MediatR;
using ProSpaceTestTask.Models;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.RedactUser;

public class RedactUserHandler : IRequestHandler<RedactUserRequest, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;

    public RedactUserHandler(IUserRepository userRepository, ICustomerRepository customerRepository)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(RedactUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id, cancellationToken);
        if (user == null)
        {
            return Result.Fail("Пользователь не найден!");
        }

        var role = await _userRepository.GetRoleByName(request.RoleName, cancellationToken);
        if (role == null)
        {
            return Result.Fail("Роль не найдена!");
        }
        
        user.Login = request.Login;
        user.Password = request.Password;

        if (user.Role.Name != request.RoleName)
        {
            if (request.RoleName == "customer")
            {
                UpdateCustomerInfo(user, request);
            }
            else if (request.RoleName == "administrator")
            {
                user.Customer = null;
            }

            user.Role = role;
        }
        else
        {
            UpdateCustomerInfo(user, request);
        }
        _userRepository.Update(user);
        await _userRepository.SaveChanges(cancellationToken);
        return Result.Ok();
    }

    private void UpdateCustomerInfo(User user, RedactUserRequest request)
    {
        var customer = user.Customer ?? new Customer()
        {
            Name = request.Name,
            Address = request.Address,
            Code = request.Code,
            Discount = request.Discount,
            Cart = new Cart()
        };
        customer.Name = request.Name;
        customer.Address = request.Address;
        customer.Code = request.Code;
        customer.Discount = request.Discount;

        user.Customer = customer;
    }
}