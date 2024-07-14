namespace LicenseManagement.Models;

public partial class LisansIstek
{
    public int Id { get; set; }

    public int IstekYapanId { get; set; }

    public int? IstekKullaniciId { get; set; }

    public DateTime IstekTarihi { get; set; }

    public bool? OnayDurumu { get; set; }

    public int? OnaylayanId { get; set; }

    public DateTime? OnaylamaTarihi { get; set; }

    public int? LisansTuru { get; set; }

    public DateTime LisansBitisTarihi { get; set; }

    public int MusteriId { get; set; }

    public int BilgisayarId { get; set; }

    public string? MakinaKullaniciAdi { get; set; }

    public string? MakinaKullaniciPckey { get; set; }

    public bool Kullanabilir { get; set; }

    public DateTime? LisansAlinmaTarihi { get; set; }

    public bool YenidenLisansUret { get; set; }
}
