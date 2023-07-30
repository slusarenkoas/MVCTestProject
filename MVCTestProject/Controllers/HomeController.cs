using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCTestProject.Models;

namespace MVCTestProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private static int _id = 1;
    private static readonly List<Product> _products = new()
    {
        new Product { Name = "Yes", Description = "No", Count = 50, Price = 30, Id = _id++},
        new Product { Name = "Yes", Description = "No", Count = 50, Price = 30, Id = _id++ },
        new Product { Name = "Yes", Description = "No", Count = 50, Price = 30, Id = _id++ },
    };
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new IndexModel
        {
            Products = _products
        };
        return View(model);
    }
    
    [HttpPost("create-product")]
    public IActionResult CreateProduct ([FromForm] Product newProduct)
    {
        newProduct.Id = _id++;
        _products.Add(newProduct);
        return RedirectToAction ("Index","Home");
    }

    [HttpPost("delete-product")]
    public IActionResult DeleteProduct (int id)
    {
        var model = _products.Find(x => x.Id == id);
        _products.Remove(model);
        return RedirectToAction ("Index","Home");
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [HttpPost("upgrade-product")]
    public IActionResult UpdateProduct(int id,[FromForm] Product updatedProduct)
    {
        var productToUpdate = _products.Find(p => p.Id == id);
        if (productToUpdate != null)
        {
            productToUpdate.Name = updatedProduct.Name;
            productToUpdate.Description = updatedProduct.Description;
            productToUpdate.Price = updatedProduct.Price;
            productToUpdate.Count = updatedProduct.Count;
        }
        return RedirectToAction("Index");
    }
    
    public IActionResult Table()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}