using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMicroservices.OrdersManagement.Api.Applications;
using ShopMicroservices.OrdersManagement.Api.DataAccess;

namespace ShopMicroservices.OrdersManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(ShopApplicationService shopApplicationService, ILogger<OrdersController> logger) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderCommand command)
    {
        var order = shopApplicationService.HandleOrder(command);
        return Ok(order);
    }
}

public record OrderCommand(int OrderId);
