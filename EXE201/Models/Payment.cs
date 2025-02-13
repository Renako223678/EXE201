using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Payment
{
    public long Id { get; set; }

    public long BookingId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public double Amount { get; set; }

    public string Status { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
