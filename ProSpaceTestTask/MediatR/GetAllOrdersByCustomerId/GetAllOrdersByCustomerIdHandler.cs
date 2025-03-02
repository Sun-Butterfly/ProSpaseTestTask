using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.GetAllOrdersByCustomerId;

public class GetAllOrdersByCustomerIdHandler : IRequestHandler<GetAllOrdersByCustomerIdRequest, Result<GetAllOrdersByCustomerIdResponse>>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrdersByCustomerIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result<GetAllOrdersByCustomerIdResponse>> Handle(GetAllOrdersByCustomerIdRequest request, CancellationToken cancellationToken)
    {
        var customerIdGuid = Guid.Parse(request.CustomerId);
        var orders = await _orderRepository.GetAllByCustomerId(customerIdGuid, cancellationToken);
        
        return Result.Ok(new GetAllOrdersByCustomerIdResponse(orders));
    }
}