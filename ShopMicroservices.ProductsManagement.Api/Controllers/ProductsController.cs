using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMicroservices.ProductsManagement.Api.DataAccess;
using ShopMicroservices.ProductsManagement.Api.Models;
using System.Net;

namespace ShopMicroservices.ProductsManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(ProductsManagementDBContext context, ILogger<ProductsController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        { 
            var products = await context.Products.Include(p=>p.Category).ToListAsync();
            return products is not null ? Ok(products): NotFound();
        }

        [HttpGet("{id}", Name =nameof(GetProductById))]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await context.Products
                .Include(p => p.Category)
                .Where(p=>p.Id==id)
                .FirstOrDefaultAsync();

            return product is not null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto newProduct)
        {
            try
            {
                var product = newProduct.ToProduct();
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
                return CreatedAtRoute(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}