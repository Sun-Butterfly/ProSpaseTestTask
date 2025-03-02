using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

public interface ICartRepository
{
    Task<CartItem?> GetCartItemByItemId(Guid cartId, Guid itemId, CancellationToken cancellationToken);
    Task<Cart?> GetByCustomerId(Guid customerId, CancellationToken cancellationToken);
    void Add(CartItem cartItem);
    Task SaveChanges(CancellationToken cancellationToken);
    Task<List<CartItem>?> GetCartItemsByIds(List<long> selectedCartItemIds, CancellationToken cancellationToken);
    void RemoveCartItems(List<CartItem> selectedCartItems);
    Task<List<GetCartItemByCartIdDto>> GetCartItemsByCartId(Guid cartId, CancellationToken cancellationToken);
}