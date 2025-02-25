using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.CreateOrder;

public record CreateOrderRequest(
    List<long> SelectedCartItemIds,
    Guid CustomerId
) : IRequest<Result>;