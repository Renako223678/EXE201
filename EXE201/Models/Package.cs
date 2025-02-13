﻿using System;
using System.Collections.Generic;

namespace EXE201.Models;

public partial class Package
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public long DestinationId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Rating { get; set; }

    public double Price { get; set; }

    public bool IsActive { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Destination Destination { get; set; } = null!;

    public virtual ICollection<Itinerary> Itineraries { get; set; } = new List<Itinerary>();

    public virtual ICollection<PackageService> PackageServices { get; set; } = new List<PackageService>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
