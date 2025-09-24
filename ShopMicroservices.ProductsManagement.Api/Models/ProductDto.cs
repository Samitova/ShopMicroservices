namespace ShopMicroservices.ProductsManagement.Api.Models;

public record ProductDto(
    string Sku,
    string Name,
    string Description,
    decimal Price,
    int QuantityInStock,
    int CategoryId)
{
    public Product ToProduct()
    { 
        return new Product()
        {
            Id = 0,
            Sku = Sku,
            Name = Name,
            Description = Description,
            Price = Price,
            QuantityInStock = QuantityInStock,
            CategoryId = CategoryId
        };
    }
}
