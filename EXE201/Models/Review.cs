﻿using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Review
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public long PackageId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; } = null!;

    public DateOnly CreateDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;
}
