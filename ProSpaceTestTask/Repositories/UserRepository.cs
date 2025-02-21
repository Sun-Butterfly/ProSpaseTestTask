using Microsoft.EntityFrameworkCore;
using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

class UserRepository : IUserRepository
{
    private readonly DatabaseContext _db;

    public UserRepository(DatabaseContext db)
    {
        _db = db;
    }

    public void Add(User user)
    {
        _db.Add(user);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetByLogin(string login, CancellationToken cancellationToken)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Login == login, cancellationToken);
    }

    public async Task<User?> GetByLoginAndPassword(string login, string password, CancellationToken cancellationToken)
    {
        return await _db.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Login == login && x.Password == password, cancellationToken);
    }

    public async Task<User?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Users
            .Include(x=>x.Role)
            .Include(x=>x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Update(User user)
    {
        _db.Update(user);
    }

    public async Task ChangeRoleByRoleName(string roleName, Guid id, CancellationToken cancellationToken)
    {
        var user = await _db.Users.FirstAsync(x => x.Id == id, cancellationToken);
        
        switch (roleName)
        {
            case "customer":
                user.RoleId = 2;
                break;
            case "administrator":
                user.RoleId = 1;
                break;
        }
    }

    public async Task<Role?> GetRoleByName(string roleName, CancellationToken cancellationToken)
    {
        return await _db.Roles.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
    }
}