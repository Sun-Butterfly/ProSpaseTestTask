using FluentResults;
using MediatR;
using ProSpaceTestTask.Models;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.CloseOrderById;

public class CloseOrderByIdHandler : IRequestHandler<CloseOrderByIdRequest, Result>
{
    private readonly IOrderRepository _orderRepository;

    public CloseOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result> Handle(CloseOrderByIdRequest request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetById(request.OrderId, cancellationToken);
        if (order == null)
        {
            return Result.Fail("Заказ не найден!");
        }
        
        order.Status = OrderStatus.Completed.ToString();
        
        _orderRepository.Update(order);
        await _orderRepository.SaveChanges(cancellationToken);
        return Result.Ok();
    }
}