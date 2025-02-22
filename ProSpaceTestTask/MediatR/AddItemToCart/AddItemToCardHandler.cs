using FluentResults;
using MediatR;
using ProSpaceTestTask.Models;
using ProSpaceTestTask.Repositories;

namespace ProSpaceTestTask.MediatR.AddItemToCart;

public class AddItemToCardHandler : IRequestHandler<AddItemToCardRequest, Result>
{
    private readonly IItemRepository _itemRepository;
    private readonly ICartRepository _cartRepository;

    public AddItemToCardHandler(IItemRepository itemRepository, ICartRepository cartRepository)
    {
        _itemRepository = itemRepository;
        _cartRepository = cartRepository;
    }

    public async Task<Result> Handle(AddItemToCardRequest request, CancellationToken cancellationToken)
    {

        var cart = await _cartRepository.GetByCustomerId(request.CustomerId, cancellationToken);
        if (cart == null)
        {
            return Result.Fail("Корзина не найдена!");
        }
        var cartItem = await _cartRepository.GetCartItemByItemId(cart.Id, request.ItemId, cancellationToken);

        if (cartItem != null)
        {
            cartItem.ItemsCount += request.ItemCount;
        }
        else
        {
            cartItem = new CartItem()
            {
                Cart = cart,
                ItemId = request.ItemId,
                ItemsCount = request.ItemCount
            };
            _cartRepository.Add(cartItem);
        }

        await _cartRepository.SaveChanges(cancellationToken);
        
        return Result.Ok();
    }
}