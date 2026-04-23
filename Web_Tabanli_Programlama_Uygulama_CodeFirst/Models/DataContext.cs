using Microsoft.EntityFrameworkCore;
namespace Web_Tabanli_Programlama_Uygulama_CodeFirst.Models

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Web_Tabanli_Programlama_Uygulama_CodeFirst.Models.Ogrenci> Ogrenciler { get; set; }
    }
}