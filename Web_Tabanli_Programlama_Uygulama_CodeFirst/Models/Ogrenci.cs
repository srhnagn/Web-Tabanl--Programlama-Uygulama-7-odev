namespace Web_Tabanli_Programlama_Uygulama_CodeFirst.Models
{
    public class Ogrenci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sinif { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public string Sehir { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}