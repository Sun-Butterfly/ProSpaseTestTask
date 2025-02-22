namespace ProSpaceTestTask.Models;

public class Item
{
    public Guid Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public string Category { get; set; } = "";

    public List<OrderElement> OrderElements { get; set; } = new();
    public List<CartItem> CartItems { get; set; } = new();
}