using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using admin.Models;

namespace admin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [Route("/överdelar")]
    public IActionResult Tops()
    {
        return View();
    }
    [Route("/underdelar")]
    public IActionResult Bottoms()
    {
        return View();
    }
    [Route("/skor")]
    public IActionResult Shoes()
    {
        return View();
    }
    [Route("/badkläder")]
    public IActionResult Swimsuits()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
