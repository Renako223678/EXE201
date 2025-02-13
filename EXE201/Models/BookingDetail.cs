﻿using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class BookingDetail
{
    public long Id { get; set; }

    public long BookingId { get; set; }

    public long PackageId { get; set; }

    public bool IsActive { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;
}
