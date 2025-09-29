namespace ShopMicroservices.OrdersManagement.Api.Models;

public record ProductInfo(
    int Id,
    string Name,
    string Sku, 
    string Description, 
    decimal Price, 
    int QuantityInStock, 
    int CategoryId);
