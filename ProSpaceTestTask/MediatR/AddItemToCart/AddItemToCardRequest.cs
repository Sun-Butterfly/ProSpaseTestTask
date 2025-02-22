using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.AddItemToCart;

public record AddItemToCardRequest(
    Guid CustomerId,
    Guid ItemId,
    int ItemCount
) : IRequest<Result>;