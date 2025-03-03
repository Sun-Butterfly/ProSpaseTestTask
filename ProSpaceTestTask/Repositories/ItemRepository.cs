using Microsoft.EntityFrameworkCore;
using ProSpaceTestTask.DTOs;
using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

class ItemRepository : IItemRepository
{
    private readonly DatabaseContext _db;

    public ItemRepository(DatabaseContext db)
    {
        _db = db;
    }

    public void Add(Item item)
    {
        _db.Items.Add(item);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }

    public void Update(Item item)
    {
        _db.Items.Update(item);
    }

    public async Task<List<GetAllItemsDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _db.Items
            .Select(x => new GetAllItemsDto(
                x.Id,
                x.Code,
                x.Name,
                x.Price,
                x.Category))
            .ToListAsync(cancellationToken);
    }

    public async Task<Item?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Items.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task Delete(Item item, CancellationToken cancellationToken)
    {
        await _db.Items
            .Where(x => x.Id == item.Id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<GetItemByIdDto> GetByIdDto(Guid idGuid, CancellationToken cancellationToken)
    {
        var item = await _db.Items.FirstOrDefaultAsync(x => x.Id == idGuid, cancellationToken);
        return new GetItemByIdDto(
            item.Name,
            item.Price,
            item.Category
        );
    }
}