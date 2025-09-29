using ShopMicroservices.OrdersManagement.Api.Models;

namespace ShopMicroservices.OrdersManagement.Api.ExternalServices;

public class ProductManagementService(HttpClient client)
{
    public async Task<ProductInfo> GetProductInfo(int id)
    { 
        var productInfo =await client.GetFromJsonAsync<ProductInfo> ($"/api/products/{id}");
        return productInfo;
    }
}
