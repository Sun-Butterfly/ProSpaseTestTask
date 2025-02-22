using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Item>> GetAll(CancellationToken cancellationToken)
    {
        return await _db.Items.ToListAsync(cancellationToken);
    }
}