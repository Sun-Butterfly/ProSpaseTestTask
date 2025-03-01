using ProSpaceTestTask.DTOs;
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
    Task<Role?> GetRoleByName(string roleName, CancellationToken cancellationToken);
    Task Delete(User user, CancellationToken cancellationToken);
    Task<List<GetAllUsersDto>> GetAll(CancellationToken cancellationToken);
}