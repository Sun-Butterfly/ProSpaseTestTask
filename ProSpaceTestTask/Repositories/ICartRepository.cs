using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

public interface ICartRepository
{
    Task<CartItem?> GetCartItemByItemId(Guid cartId, Guid itemId, CancellationToken cancellationToken);
    Task<Cart?> GetByCustomerId(Guid customerId, CancellationToken cancellationToken);
    void Add(CartItem cartItem);
    Task SaveChanges(CancellationToken cancellationToken);
}