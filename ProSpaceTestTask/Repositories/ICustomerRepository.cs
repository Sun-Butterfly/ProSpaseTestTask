using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

public interface ICustomerRepository
{
    void Add(Customer customer);
    Task SaveChanges(CancellationToken cancellationToken);
}