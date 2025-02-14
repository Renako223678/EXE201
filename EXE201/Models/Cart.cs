using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Cart
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public bool IsActive { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
