using System.Text.Json.Serialization;

namespace ShopMicroservices.OrdersManagement.Api.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ShippedAt { get; set; }
    public string ShippingAddress { get; set; }
    public int CustomerId { get; set; }

    [JsonIgnore]
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
