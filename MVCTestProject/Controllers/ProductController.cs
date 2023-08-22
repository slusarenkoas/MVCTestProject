using Microsoft.AspNetCore.Mvc;
using MVCTestProject.Models;

namespace MVCTestProject.Controllers;

[Route("controller")]
public class ProductController : ControllerBase
{
    public static readonly List<Product> _products = new()
    {
        new Product { Name = "Yes", Description = "No", Count = 50, Price = 30},
        new Product { Name = "Yes", Description = "No", Count = 50, Price = 30},
        new Product { Name = "Yes", Description = "No", Count = 50, Price = 30},
    };

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct([FromRoute] int id)
    {
        return _products[id];
    }
    
    [HttpPost("{id}")]
    public ActionResult<Product> SetProduct([FromRoute] int id, [FromBody] Product updatedProduct)
    {
        return _products[id] = updatedProduct;
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct([FromRoute] int id)
    {
        _products.RemoveAt(id);
        return RedirectToAction("Index", "Home");
    }
    
    [HttpPost]
    public ActionResult<Product> CreateProduct([FromBody] Product newProduct)
    {
        _products.Add(newProduct);
        return newProduct;
    }
}