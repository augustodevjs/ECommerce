namespace ECommerce.Domain.Entities;

public class OrderItem
{
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public decimal UnitValue { get; set; }
}
