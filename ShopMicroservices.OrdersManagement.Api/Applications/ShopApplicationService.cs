using ShopMicroservices.OrdersManagement.Api.Controllers;
using ShopMicroservices.OrdersManagement.Api.DataAccess;
using ShopMicroservices.OrdersManagement.Api.ExternalServices;
using ShopMicroservices.OrdersManagement.Api.Models;

namespace ShopMicroservices.OrdersManagement.Api.Applications;

public class ShopApplicationService(
    OrdersManagementDBContext context, 
    ProductManagementService productManagementService)
{
    public async Task<Order> HandleOrder(OrderCommand command)
    {
        var productInfo = productManagementService.GetProductInfo(command.OrderId);

        var newOrder = new Order(); //TODO add logic

        await context.Orders.AddAsync(newOrder);
        await context.SaveChangesAsync();
        return newOrder;
    }

}
