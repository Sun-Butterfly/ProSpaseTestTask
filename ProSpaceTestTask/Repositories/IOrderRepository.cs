using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Task SaveChanges(CancellationToken cancellationToken);
    Task<Order?> GetById(Guid orderId, CancellationToken cancellationToken);
    void Update(Order order);
    Task Delete(Order order, CancellationToken cancellationToken);
    Task<List<GetAllOrdersByCustomerIdDto>> GetAllByCustomerId(Guid customerId, CancellationToken cancellationToken);
    Task<List<GetAllOrdersDto>> GetAll(CancellationToken cancellationToken);
}