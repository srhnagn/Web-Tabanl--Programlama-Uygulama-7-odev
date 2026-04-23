using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_Tabanli_Programlama_Uygulama_DbFirst.Models;

namespace Web_Tabanli_Programlama_Uygulama_DbFirst.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
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
