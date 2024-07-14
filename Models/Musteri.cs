namespace LicenseManagement.Models;

public partial class Musteri
{

    public int Id { get; set; }

    public string? MusteriAdi { get; set; }

    public string? MusteriAdres { get; set; }

    public string? MusteriTelefon { get; set; }

    public int IlId { get; set; }

    public int IlceId { get; set; }

    public int VergiDairesiId { get; set; }

    public string? MusteriVergiNo { get; set; }

    public string? MusteriOzel { get; set; }

    public DateTime KayitTarihi { get; set; }

    public bool GuncellemeAlabilir { get; set; }

    public bool Kullanabilir { get; set; }

    public DateTime LisansBitisTarihi { get; set; }

    public string? YetkiliAdi { get; set; }

    public string? YetkiliTelefon { get; set; }

    public string? Note { get; set; }
}