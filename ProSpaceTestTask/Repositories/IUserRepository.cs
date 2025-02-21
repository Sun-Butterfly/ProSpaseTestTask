using ProSpaceTestTask.Models;

namespace ProSpaceTestTask.Repositories;

public interface IUserRepository
{
    void Add(User user);
    Task SaveChanges(CancellationToken cancellationToken);
    Task<User?> GetByLogin(string login, CancellationToken cancellationToken);
    Task<User?> GetByLoginAndPassword(string login, string password, CancellationToken cancellationToken);
    Task<User?> GetById(Guid id, CancellationToken cancellationToken);
    void Update(User user);
    Task ChangeRoleByRoleName(string roleName, Guid id, CancellationToken cancellationToken);
    Task<Role?> GetRoleByName(string roleName, CancellationToken cancellationToken);
}