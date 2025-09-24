namespace ShopMicroservices.ProductsManagement.Api.Models;

public record CategoryDto(
    string Name,
    string Description)
{
    public Category ToProduct()
    {
        return new Category()
        {
            Id = 0,
            Name = Name,
            Description = Description
        };
    }
}