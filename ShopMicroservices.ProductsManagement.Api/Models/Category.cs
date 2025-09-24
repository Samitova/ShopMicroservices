using System.Text.Json.Serialization;

namespace ShopMicroservices.ProductsManagement.Api.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; }
}