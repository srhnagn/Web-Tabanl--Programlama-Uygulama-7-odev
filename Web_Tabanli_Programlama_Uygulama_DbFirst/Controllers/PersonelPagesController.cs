using Microsoft.AspNetCore.Mvc;
namespace Web_Tabanli_Programlama_Uygulama_DbFirst.Controllers
{
    public class PersonelPagesController : Controller
    {

        // 1. Hocanın tarzı: Hem new ile tanımla hem de Injection ile ez.
        
        DataContext DataContext = new DataContext();

        public IActionResult PersonelController(DataContext _context)
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
        public IActionResult PersonelKaydet(Personel PersonelModel)
        {
            context.Personeller.Add(PersonelModel)
            context.SaveChanges();
            return View("Thanks", PersonelModel);
        }
        
        // --- SİLME (POST) ---
        [HttpPost]
        public IActionResult Sil(int id)
        {
            var deger = context.Personeller.Where(x => x.Id == id).FirstOrDefault();
            context.Personeller.Remove(deger);
            context.SaveChanges();
            
            return View();
        }

        // --- GÜNCELLEME (GET) --- TextBox'ları dolduruyoruz
        [HttpGet]
        public IActionResult GuncellenecegiGetir(int id)
        {
            // Hocanın tarzı: Where ve FirstOrDefault
            var deger = context.Personeller.Where(x => x.Id == id).FirstOrDefault();
            return View(deger);
        }

        // --- GÜNCELLEME (POST) --- Veritabanına yazar
        [HttpPost]
        public IActionResult Guncelle(Personel entity, Personel gizli = null)
        {
            // Hocanın tarzı: Manuel alan eşleme mantığı
            if(gizli == null)
            {
                gizli = context.Personeller.Where(p => p.Id == entity.Id).FirstOrDefault();
            }
            else
            {
                context.Personeller.Attach(gizli);
            }

            if(gizli != null)
            {
                // BURASI ÖNEMLİ: Kendi Urun modelindeki özellikleri buraya tek tek yazmalısın
                gizli.Ad = entity.Ad;
                gizli.Fiyat = entity.Fiyat;
                // Eğer başka özelliklerin varsa onları da buraya ekle
                
                context.SaveChanges();
            }
            
            return View();
        }

    }
}