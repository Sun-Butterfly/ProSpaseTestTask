namespace ProSpaceTestTask.Models;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public string Address { get; set; } = "";
    public int Discount { get; set; }

    public User? User { get; set; }

    public List<Order> Orders { get; set; } = new();
}