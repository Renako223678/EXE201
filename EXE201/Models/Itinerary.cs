﻿using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Itinerary
{
    public long Id { get; set; }

    public long PackageId { get; set; }

    public DateTime Date { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual Package Package { get; set; } = null!;
}
