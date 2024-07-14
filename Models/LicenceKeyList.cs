using System;
using System.Collections.Generic;

namespace LicenseManagement.Models;

public partial class LicenceKeyList
{
    public int Id { get; set; }

    public string? LicenceKey { get; set; }

    public DateTime ChangeDate { get; set; }
}
