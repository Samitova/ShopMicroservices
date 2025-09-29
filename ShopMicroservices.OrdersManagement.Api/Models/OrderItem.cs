namespace ShopMicroservices.OrdersManagement.Api.Models;

public class OrderItem
{
    public int OrderedQuantity { get; set; }
    public decimal UnitPrice { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}
