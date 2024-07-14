namespace LicenseManagement.Models;

public partial class Bilgisayar
{
    public string? Isim { get; set; }

    public int MusteriId { get; set; }

    public string? Pckey { get; set; }

    public bool Kullanabilir { get; set; }

    public DateTime LisansTarihi { get; set; }

    public DateTime LisansBitisTarihi { get; set; }

    public bool GuncellemeAlabilir { get; set; }

    public int MakinaNo { get; set; }

    public string? MakinaCpuId { get; set; }

    public string? MakinaPcadi { get; set; }

    public DateTime DemoLisansBitisTarihi { get; set; }

    public int TerminalSayisi { get; set; }

    public int Id { get; set; }

}
