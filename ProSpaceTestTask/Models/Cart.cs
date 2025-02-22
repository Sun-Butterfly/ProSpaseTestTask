namespace ProSpaceTestTask.Models;

public class Cart
{
    public Guid Id { get; set; }
    public Customer Customer { get; set; } = null!;
    public List<CartItem> CartItems { get; set; } = new();
}