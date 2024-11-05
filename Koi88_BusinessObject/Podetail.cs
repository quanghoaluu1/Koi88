﻿using System;
using System.Collections.Generic;

namespace Koi88_BusinessObject;

public partial class Podetail
{
    public int PoDetailId { get; set; }

    public int? PoId { get; set; }

    public int? KoiId { get; set; }

    public int? FarmId { get; set; }

    public decimal? Deposit { get; set; }

    public decimal? TotalKoiPrice { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? Day { get; set; }

    public string? Note { get; set; }

    public virtual KoiFarm? Farm { get; set; }

    public virtual KoiFish? Koi { get; set; }

    public virtual Po? Po { get; set; }
}
