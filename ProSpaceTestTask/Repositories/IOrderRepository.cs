using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Task SaveChanges(CancellationToken cancellationToken);
    Task<Order?> GetById(Guid orderId, CancellationToken cancellationToken);
    void Update(Order order);
}