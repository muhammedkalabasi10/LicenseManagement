namespace LicenseManagement.Models;

public partial class Kullanici
{
    public int Id { get; set; }

    public string? KullaniciAdi { get; set; }

    public string? Eposta { get; set; }

    public string? Isim { get; set; }

    public string? Sifre { get; set; }

    public bool IsRealUser { get; set; }
}
