using System;
using System.Collections.Generic;

namespace Koi88_BusinessObject;

public partial class Trip
{
    public int TripId { get; set; }

    public string? TripName { get; set; }

    public decimal? PriceTotal { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<TripDetail> TripDetails { get; set; } = new List<TripDetail>();
}
