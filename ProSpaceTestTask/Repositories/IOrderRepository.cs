using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Task SaveChanges(CancellationToken cancellationToken);
}