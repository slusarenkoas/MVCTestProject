using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCTestProject.Models;

namespace MVCTestProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new IndexModel
        {
            Products = ProductController._products
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

