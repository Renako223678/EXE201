using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Discount
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public int Percentage { get; set; }

    public DateTime ExpiryDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
