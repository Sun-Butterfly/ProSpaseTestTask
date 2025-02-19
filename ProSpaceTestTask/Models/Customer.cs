namespace ProSpaceTestTask.Models;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public string Address { get; set; } = "";
    public int Discount { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public List<Order> Orders { get; set; } = new();
}