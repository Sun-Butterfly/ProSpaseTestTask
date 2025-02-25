using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

public interface ICustomerRepository
{
    void Add(Customer customer);
    Task SaveChanges(CancellationToken cancellationToken);
    void Delete(Customer customer);
    Task<Customer?> GetById(Guid customerId, CancellationToken cancellationToken);
}