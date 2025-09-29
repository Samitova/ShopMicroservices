using Microsoft.EntityFrameworkCore;
using ShopMicroservices.OrdersManagement.Api.Models;

namespace ShopMicroservices.OrdersManagement.Api.DataAccess;

public class OrdersManagementDBContext(DbContextOptions<OrdersManagementDBContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}

public static class OrdersManagementDBContextExtentions
{
    public static void EnsureDbIsCreated(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<OrdersManagementDBContext>();
        context!.Database.EnsureCreated();
    }
}