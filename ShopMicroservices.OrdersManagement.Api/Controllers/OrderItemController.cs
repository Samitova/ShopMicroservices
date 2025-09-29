using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMicroservices.OrdersManagement.Api.DataAccess;

namespace ShopMicroservices.OrdersManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderItemController(OrdersManagementDBContext context, ILogger<OrderItemController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOrderItems()
    {
        var orderItems = await context.OrderItems.ToListAsync();
        return orderItems is not null ? Ok(orderItems) : NotFound();
    }
}