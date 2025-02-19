namespace ProSpaceTestTask.Models;

public class Order
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShipmentDate { get; set; }
    public long OrderNumber { get; set; }
    public string Status { get; set; } = "";
    
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public List<OrderElement> OrderElements { get; set; } = new();
    
}