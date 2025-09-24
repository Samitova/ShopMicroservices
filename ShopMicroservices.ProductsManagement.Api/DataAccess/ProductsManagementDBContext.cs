using Microsoft.EntityFrameworkCore;
using ShopMicroservices.ProductsManagement.Api.Models;

namespace ShopMicroservices.ProductsManagement.Api.DataAccess;

public class ProductsManagementDBContext(DbContextOptions<ProductsManagementDBContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
        [
            new Category {
                Id = 1,
                Name = "Toys",
                Description="Cool toys" 
            },
            new Category {
                Id = 2,
                Name = "Books",
                Description="Books for your fun" 
            },
            new Category {
                Id = 3,
                Name = "Games",
                Description="Games for your fun"
            }
        ]);
        modelBuilder.Entity<Product>().HasData(
        [
            new Product{
                Id = 1,
                Name = "Doll",
                Sku="223F-23",
                Description="Wonderfull toy for girls",
                Price = 21m,
                QuantityInStock=3,
                CategoryId = 1
            },
            new Product{
                Id = 2,
                Name = "Ball",
                Sku="22ball-26",
                Description="Bouncing ball",
                Price = 11m,
                QuantityInStock=1,
                CategoryId = 1
            },
            new Product{
                Id = 3,
                Name = "Kite",
                Sku="22gg3",
                Description="Flies up high",
                Price = 15.75m,
                QuantityInStock=0,
                CategoryId = 1
            },
            new Product{
                Id = 4,
                Name = "My Fate",
                Sku="FG677",
                Description="Just fate",
                Price = 14.50m,
                QuantityInStock=30,
                CategoryId = 2
            },
            new Product{
                Id = 5,
                Name = "Stories for kids",
                Sku="223F-4",
                Description="Wonderfull stories for kids",
                Price = 121m,
                QuantityInStock=5,
                CategoryId = 2
            }
        ]);
    }
}

public static class ProductsManagementDBContextExtentions
{
    public static void EnsureDbIsCreated(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<ProductsManagementDBContext>();
        context!.Database.EnsureCreated();
    }
}