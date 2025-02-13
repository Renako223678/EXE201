using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Destination
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}
