using System;
using System.Collections.Generic;

namespace Web_Tabanli_Programlama_Uygulama_DbFirst.Models;

public partial class Personel
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Departman { get; set; } = null!;

    public string Eposta { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Sehir { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
