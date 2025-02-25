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
}