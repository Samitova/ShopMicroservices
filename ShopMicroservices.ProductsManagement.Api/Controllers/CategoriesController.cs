using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMicroservices.ProductsManagement.Api.DataAccess;
using ShopMicroservices.ProductsManagement.Api.Models;
using System.Net;

namespace ShopMicroservices.ProductsManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController(ProductsManagementDBContext context, ILogger<CategoriesController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await context.Categories.ToListAsync();
        return categories is not null ? Ok(categories) : NotFound();
    }

    [HttpGet("{id}", Name = nameof(GetCategoryById))]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await context.Categories
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

        return category is not null ? Ok(category) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryDto newCategory)
    {
        try
        {
            var category = newCategory.ToProduct();
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return CreatedAtRoute(nameof(GetCategoryById), new { id = category.Id }, category);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}