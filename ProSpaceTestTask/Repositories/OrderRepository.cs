using Microsoft.EntityFrameworkCore;
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
}