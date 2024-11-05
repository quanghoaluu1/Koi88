﻿using System;
using System.Collections.Generic;

namespace Koi88_BusinessObject;

public partial class KoiFarm
{
    public int FarmId { get; set; }

    public string? FarmName { get; set; }

    public string? Location { get; set; }

    public string? ContactInfo { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Podetail> Podetails { get; set; } = new List<Podetail>();

    public virtual ICollection<SpecialVariety> SpecialVarieties { get; set; } = new List<SpecialVariety>();

    public virtual ICollection<TripDetail> TripDetails { get; set; } = new List<TripDetail>();
}
