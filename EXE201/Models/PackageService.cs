using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class PackageService
{
    public long Id { get; set; }

    public long PackageId { get; set; }

    public long ServiceId { get; set; }

    public double Price { get; set; }

    public bool IsActive { get; set; }

    public virtual Package Package { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
