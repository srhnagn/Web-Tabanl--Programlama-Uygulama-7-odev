using Microsoft.AspNetCore.Mvc;
using Web_Tabanli_Programlama_Uygulama_DbFirst.Models;
namespace Web_Tabanli_Programlama_Uygulama_DbFirst.Controllers
{
    public class PersonelPagesController : Controller
    {

        // 1. Hocanın tarzı: Hem new ile tanımla hem de Injection ile ez.
        
        Models.DataContext context = new Models.DataContext();

        public PersonelPagesController(Models.DataContext _context)
        {
            context = _context;
        }

        // --- EKLEME (GET ile bos sayfayı getirtiyoruz) ---
        [HttpGet]
        public IActionResult PersonelEkle()
        {
            return View();
        }

        // --- EKLEME (POST ile veritabanına kaydediyoruz) ---
        [HttpPost]
        public IActionResult PersonelKaydet(Models.Personel PersonelModel)
        {
            context.Personels.Add(PersonelModel);
            context.SaveChanges();
            return View("Thanks", PersonelModel);
        }
        
        // --- SİLME (POST) ---
        [HttpPost]
        public IActionResult Sil(int id)
        {
            var deger = context.Personels.Where(x => x.Id == id).FirstOrDefault();
            context.Personels.Remove(deger);
            context.SaveChanges();
            
            return View("Done");
        }

        // --- GÜNCELLEME ve SİLME (GET) --- TextBox'ları dolduruyoruz
        [HttpGet]
        public IActionResult GuncellenecegiGetir(int id)
        {
            // Hocanın tarzı: Where ve FirstOrDefault
            var deger = context.Personels.Where(x => x.Id == id).FirstOrDefault();
            return View("PersonelGuncelleSil", deger);
        }

        // --- GÜNCELLEME (POST) --- Veritabanına yazar
        [HttpPost]
        public IActionResult Guncelle(Models.Personel entity)
        {
            var gizli = context.Personels.Where(p => p.Id == entity.Id).FirstOrDefault();

            if(gizli != null)
            {
                gizli.Ad = entity.Ad;
                gizli.Soyad = entity.Soyad;
                gizli.Eposta = entity.Eposta;
                gizli.Telefon = entity.Telefon;
                gizli.Departman = entity.Departman;
                gizli.Sehir = entity.Sehir;
                context.SaveChanges();
            }
            
            return View("Done");
        }

        public IActionResult PersonelListele()
        {
            // Veritabanından tüm personelleri çek
            var liste = context.Personels.ToList();

            // Listeyi View'e gönder
            return View(liste);
        }


    }
}