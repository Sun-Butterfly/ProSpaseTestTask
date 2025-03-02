using Microsoft.EntityFrameworkCore;
using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

class OrderRepository : IOrderRepository
{
    private readonly DatabaseContext _db;

    public OrderRepository(DatabaseContext db)
    {
        _db = db;
    }


    public void Add(Order order)
    {
        _db.Orders.Add(order);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<Order?> GetById(Guid orderId, CancellationToken cancellationToken)
    {
        return await _db.Orders.FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken);
    }

    public void Update(Order order)
    {
        _db.Update(order);
    }

    public async Task Delete(Order order, CancellationToken cancellationToken)
    {
        await _db.Orders.Where(x => x.Id == order.Id).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<GetAllOrdersByCustomerIdDto>> GetAllByCustomerId(Guid customerId, CancellationToken cancellationToken)
    {
        var orders = await _db.Orders
            .Where(x => x.CustomerId == customerId)
            .ToListAsync(cancellationToken);
        
        var orderIds = orders.Select(x => x.Id).ToList();
        
        var orderElements = await _db.OrderElements
            .Where(x => orderIds.Contains(x.OrderId))
            .ToListAsync(cancellationToken);
        
        var itemIds = orderElements.Select(x => x.ItemId).Distinct().ToList();
        var items = await _db.Items
            .Where(x => itemIds.Contains(x.Id))
            .ToListAsync(cancellationToken);
        
        var result = orders.Select(order => new GetAllOrdersByCustomerIdDto(
            order.Id,
            order.OrderDate,
            order.ShipmentDate,
            order.OrderNumber,
            order.Status,
            orderElements
                .Where(x => x.OrderId == order.Id)
                .Select(y => new OrderElementDto(
                    y.Id,
                    items.FirstOrDefault(z => z.Id == y.ItemId)?.Name ?? "Unknown",
                    items.FirstOrDefault(z => z.Id == y.ItemId)?.Category ?? "Unknown",
                    y.ItemsCount,
                    y.ItemPrice
                )).ToList()
        )).ToList();

        return result;

    }

    public async Task<List<GetAllOrdersDto>> GetAll(CancellationToken cancellationToken)
    {
        var orders = await _db.Orders
            .ToListAsync(cancellationToken);
        
        var orderIds = orders.Select(x => x.Id).ToList();
        
        var orderElements = await _db.OrderElements
            .Where(x => orderIds.Contains(x.OrderId))
            .ToListAsync(cancellationToken);
        
        var itemIds = orderElements.Select(x => x.ItemId).Distinct().ToList();
        var items = await _db.Items
            .Where(x => itemIds.Contains(x.Id))
            .ToListAsync(cancellationToken);
        
        var result = orders.Select(order => new GetAllOrdersDto(
            order.Id,
            order.CustomerId,
            order.OrderDate,
            order.ShipmentDate,
            order.OrderNumber,
            order.Status,
            orderElements
                .Where(x => x.OrderId == order.Id)
                .Select(y => new OrderElementDto(
                    y.Id,
                    items.FirstOrDefault(z => z.Id == y.ItemId)?.Name ?? "Unknown",
                    items.FirstOrDefault(z => z.Id == y.ItemId)?.Category ?? "Unknown",
                    y.ItemsCount,
                    y.ItemPrice
                )).ToList()
        )).ToList();

        return result;
    }
}