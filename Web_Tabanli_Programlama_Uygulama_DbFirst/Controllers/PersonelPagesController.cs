using Microsoft.AspNetCore.Mvc;
namespace Web_Tabanli_Programlama_Uygulama_DbFirst.Controllers
{
    public class PersonelPagesController : Controller
    {
        [HttpGet]
        public IActionResult PersonelEkle()
        {
            return View();
        }

        DataContext DataContext = new DataContext();

        public IActionResult PersonelController(DataContext _context)
        {
            context = _context;
        }

        [HttpPost]
        public IActionResult PersonelKaydet(Personel PersonelModel)
        {
            context.Personeller.Add(PersonelModel)
            context.SaveChanges();
            return View("Thanks", PersonelModel);
        }
    }
}