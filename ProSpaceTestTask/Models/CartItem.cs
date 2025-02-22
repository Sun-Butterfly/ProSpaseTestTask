namespace ProSpaceTestTask.Models;

public class CartItem
{
    public long Id { get; set; }
    public Guid CartId { get; set; }
    public Cart Cart { get; set; } = null!;

    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public int ItemsCount { get; set; }
}