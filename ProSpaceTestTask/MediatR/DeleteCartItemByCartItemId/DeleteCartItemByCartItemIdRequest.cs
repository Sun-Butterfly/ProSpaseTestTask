using FluentResults;
using MediatR;

namespace ProSpaceTestTask.MediatR.DeleteCartItemByCartItemId;

public record DeleteCartItemByCartItemIdRequest(
    long CartItemId,
    int Count
) : IRequest<Result>;