using Microsoft.EntityFrameworkCore;
using Web_Tabanli_Programlama_Uygulama_DbFirst.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritabanı bağlantı dizesini al
var BaglantiDizesi = builder.Configuration.GetConnectionString("veritabanina_baglan");

// Veritabanı bağlantısını kur
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(BaglantiDizesi, ServerVersion.AutoDetect(BaglantiDizesi)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
