namespace LicenseManagement.Models;

public partial class Log
{
    public int Id { get; set; }

    public string? Hostip { get; set; }

    public DateTime Tarih { get; set; }

    public int? LisansIstekId { get; set; }

    public int? IstekTuru { get; set; }
}
