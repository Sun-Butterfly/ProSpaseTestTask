namespace ProSpaceTestTask.Models;

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public Customer? Customer { get; set; }
}