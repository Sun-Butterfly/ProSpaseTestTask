using FluentResults;
using MediatR;
using ProSpaceTestTask.Models;
using ProSpaceTestTask.Repositories;
using ProSpaceTestTask.Services;

namespace ProSpaceTestTask.MediatR.CreateOrder;

public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, Result>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IService _service;

    public CreateOrderHandler(IOrderRepository orderRepository, ICartRepository cartRepository, IService service,
        ICustomerRepository customerRepository)
    {
        _orderRepository = orderRepository;
        _cartRepository = cartRepository;
        _service = service;
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.CustomerId, cancellationToken);
        if (customer == null)
        {
            return Result.Fail("Заказчик не найден!");
        }

        var selectedCartItems =
            await _cartRepository.GetCartItemsByIds(request.SelectedCartItemIds, cancellationToken);
        if (selectedCartItems == null)
        {
            return Result.Fail("Выбранные товары не найдены!");
        }

        var order = new Order()
        {
            Customer = customer,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.New.ToString(),
            OrderNumber = await _service.GetOrderNumber(request.CustomerId, cancellationToken),
            OrderElements = selectedCartItems
                .Select(x => new OrderElement()
                {
                    ItemsCount = x.ItemsCount,
                    ItemId = x.ItemId,
                    ItemPrice = x.Item.Price * x.ItemsCount,
                }).ToList()
        };
        
        _orderRepository.Add(order);
        _cartRepository.RemoveCartItems(selectedCartItems);
        await _orderRepository.SaveChanges(cancellationToken);

        return Result.Ok();
    }
}