using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Service
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<PackageService> PackageServices { get; set; } = new List<PackageService>();
}
