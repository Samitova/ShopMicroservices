﻿namespace ShopMicroservices.ProductsManagement.Api.Models;

public class Product
{
    public int Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
