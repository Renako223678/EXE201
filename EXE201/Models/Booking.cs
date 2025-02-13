using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Booking
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public long? DiscountId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime BookingDate { get; set; }

    public double TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Discount? Discount { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
