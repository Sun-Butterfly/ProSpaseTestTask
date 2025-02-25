using Microsoft.EntityFrameworkCore;
using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _db;

    public CustomerRepository(DatabaseContext db)
    {
        _db = db;
    }

    public void Add(Customer customer)
    {
        _db.Add(customer);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }

    public void Delete(Customer customer)
    {
        _db.Remove(customer);
    }

    public async Task<Customer?> GetById(Guid customerId, CancellationToken cancellationToken)
    {
        return await _db.Customers.Include(x=>x.Cart).Include(x=>x.Orders)
            .FirstOrDefaultAsync(x => x.Id == customerId, cancellationToken);
    }
}