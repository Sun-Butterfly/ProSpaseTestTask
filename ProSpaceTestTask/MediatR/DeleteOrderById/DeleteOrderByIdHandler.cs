using FluentResults;
using MediatR;
using ProSpaceTestTask.Models;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.DeleteOrderById;

public class DeleteOrderByIdHandler : IRequestHandler<DeleteOrderByIdRequest, Result>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result> Handle(DeleteOrderByIdRequest request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetById(request.OrderId, cancellationToken);
        if (order == null)
        {
            return Result.Fail("Заказ не найден!");
        }

        if (order.Status == OrderStatus.Processing.ToString() || order.Status == OrderStatus.Completed.ToString())
        {
            return Result.Fail("Вы не можете удалить заказ, который находится на выполнении или уже выполнен!");
        }

        await _orderRepository.Delete(order, cancellationToken);
        await _orderRepository.SaveChanges(cancellationToken);

        return Result.Ok();
    }
}