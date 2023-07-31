using Microsoft.AspNetCore.Mvc;
using MVCTestProject.Models;

namespace MVCTestProject.Controllers;

[Route("controller")]
public class ProductController : ControllerBase
{
    private static int _id = 1;
    private static readonly List<Product> _products = new()
    {
        new Product { Name = "Yes", Description = "No", Count = 50, Price = 30, Id = _id++},
        new Product { Name = "Yes", Description = "No", Count = 50, Price = 30, Id = _id++ },
        new Product { Name = "Yes", Description = "No", Count = 50, Price = 30, Id = _id++ },
    };

    [HttpGet("{id}")]
    public Product GetProduct([FromRoute] int id)
    {
        return _products[id];
    }
    
    [HttpPost("{id}")]
    public Product SetProduct([FromRoute] int id, [FromBody] Product updatedProduct)
    {
        _products[id] = updatedProduct;
        return _products[id];
    }
}