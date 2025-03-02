using Microsoft.EntityFrameworkCore;
using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

class CartRepository : ICartRepository
{
    private readonly DatabaseContext _db;

    public CartRepository(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<CartItem?> GetCartItemByItemId(Guid cartId, Guid itemId, CancellationToken cancellationToken)
    {
        return await _db.CartItems
            .Where(x=>x.Cart.Id == cartId)
            .FirstOrDefaultAsync(x => x.ItemId == itemId, cancellationToken);
    }

    public async Task<Cart?> GetByCustomerId(Guid customerId, CancellationToken cancellationToken)
    {
        return await _db.Carts.FirstOrDefaultAsync(x => x.Id == customerId, cancellationToken);
    }

    public void Add(CartItem cartItem)
    {
        _db.CartItems.Add(cartItem);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<List<CartItem>?> GetCartItemsByIds(List<long> selectedCartItemIds,
        CancellationToken cancellationToken)
    {
        var items = await _db.CartItems.Include(x=>x.Item)
            .Where(x => selectedCartItemIds.Contains(x.Id))
            .ToListAsync(cancellationToken);
        return items;
    }

    public void RemoveCartItems(List<CartItem> selectedCartItems)
    {
        foreach (var selectedCartItem in selectedCartItems) _db.CartItems.Remove(selectedCartItem);
    }

    public async Task<List<GetCartItemByCartIdDto>> GetCartItemsByCartId(Guid cartId, CancellationToken cancellationToken)
    {
        return await _db.CartItems.Where(x => x.CartId == cartId)
            .Include(x => x.Item)
            .Select(x=> new GetCartItemByCartIdDto(
                x.Id,
                x.ItemId,
                x.Item.Name,
                x.Item.Code,
                x.Item.Price,
                x.Item.Category,
                x.ItemsCount))
            .ToListAsync(cancellationToken);
        
        
    }

    public async Task<CartItem?> GetCartItemByCartItemId(long cartItemId, CancellationToken cancellationToken)
    {
        return await _db.CartItems.FirstOrDefaultAsync(x => x.Id == cartItemId, cancellationToken);
    }

    public async Task DeleteCartItem(CartItem cartItem, CancellationToken cancellationToken)
    {
        await _db.CartItems. Where(x=>x.Id == cartItem.Id).ExecuteDeleteAsync(cancellationToken);
    }
}