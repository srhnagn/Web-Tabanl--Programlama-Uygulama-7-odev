using Microsoft.AspNetCore.Mvc;
namespace Web_Tabanli_Programlama_Uygulama_DbFirst.Controllers
{
    public class PersonelPagesController : Controller
    {
        public IActionResult PersonelEkle()
        {
            return View();
        }
    }
}