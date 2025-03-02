using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.GetAllOrders;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, Result<GetAllOrdersResponse>>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrdersHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result<GetAllOrdersResponse>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAll(cancellationToken);
        return Result.Ok(new GetAllOrdersResponse(orders));
    }
}