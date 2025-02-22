using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

public interface IItemRepository
{
    void Add(Item item);
    Task SaveChanges(CancellationToken cancellationToken);
    void Update(Item item);
    Task<List<GetAllItemsDto>> GetAll(CancellationToken cancellationToken);

    Task<Item?> GetById(Guid id, CancellationToken cancellationToken);
}