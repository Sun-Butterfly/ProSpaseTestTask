using FluentResults;
using MediatR;
using ProSpaceTestTask.Models;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.AcceptOrderById;

public class AcceptOrderByIdHandler : IRequestHandler<AcceptOrderByIdRequest, Result>
{
    private readonly IOrderRepository _orderRepository;

    public AcceptOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result> Handle(AcceptOrderByIdRequest byIdRequest, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetById(byIdRequest.OrderId, cancellationToken);
        if (order == null)
        {
            return Result.Fail("Заказ не найден!");
        }

        order.ShipmentDate = byIdRequest.ShipmentDate;
        order.Status = OrderStatus.Processing.ToString();
        
        _orderRepository.Update(order);
        await _orderRepository.SaveChanges(cancellationToken);
        return Result.Ok();
    }
}