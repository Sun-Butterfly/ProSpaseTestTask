using FluentResults;
using MediatR;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.DeleteCartItemByCartItemId;

public class DeleteCartItemByCartItemIdHandler : IRequestHandler<DeleteCartItemByCartItemIdRequest, Result>
{
    private readonly ICartRepository _cartRepository;

    public DeleteCartItemByCartItemIdHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Result> Handle(DeleteCartItemByCartItemIdRequest request, CancellationToken cancellationToken)
    {
        var cartItem = await _cartRepository.GetCartItemByCartItemId(request.CartItemId, cancellationToken);
        if (cartItem == null)
        {
            return Result.Fail("Элемент корзины не найден!");
        }

        if (request.Count < cartItem.ItemsCount)
        {
            cartItem.ItemsCount -= request.Count;
        }

        if (cartItem.ItemsCount == request.Count)
        {
            await _cartRepository.DeleteCartItem(cartItem, cancellationToken);
        }

        if (request.Count > cartItem.ItemsCount)
        {
            return Result.Fail("Нельзя удалить больше, чем есть в корзине!");
        }

        await _cartRepository.SaveChanges(cancellationToken);
        return Result.Ok();
    }
}