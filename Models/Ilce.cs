namespace LicenseManagement.Models;

public partial class Ilce
{
    public int Id { get; set; }

    public string? Adi { get; set; }

    public int IlId { get; set; }

    public int? IlceKodu { get; set; }

    public bool Etkinlik { get; set; }
}
