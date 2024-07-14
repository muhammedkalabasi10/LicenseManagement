namespace LicenseManagement.Models;

public partial class LisansMail
{
    public int Id { get; set; }

    public int LisansIstekId { get; set; }

    public Guid EmailIdentifier { get; set; }

    public DateTime Tarih { get; set; }

    public bool IsActive { get; set; }
}
