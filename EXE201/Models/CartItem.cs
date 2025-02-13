﻿using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class CartItem
{
    public long Id { get; set; }

    public long PackageId { get; set; }

    public long CartId { get; set; }

    public bool IsActive { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;
}
