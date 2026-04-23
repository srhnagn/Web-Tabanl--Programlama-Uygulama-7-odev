using Microsoft.AspNetCore.Mvc;
using Web_Tabanli_Programlama_Uygulama_CodeFirst.Models;

public class OgrenciController : Controller
{
    DataContext context;

    public OgrenciController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IActionResult OgrenciEkle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult OgrenciEkle(Ogrenci model)
    {
        context.Ogrenciler.Add(model);
        context.SaveChanges();
        return RedirectToAction("OgrenciEkle");
    }
}
