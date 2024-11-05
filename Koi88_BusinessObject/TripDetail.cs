﻿using System;
using System.Collections.Generic;

namespace Koi88_BusinessObject;

public partial class TripDetail
{
    public int TripDetailId { get; set; }

    public string? MainTopic { get; set; }

    public string? SubTopic { get; set; }

    public string? NotePrice { get; set; }

    public DateOnly? Day { get; set; }

    public int? TripId { get; set; }

    public int? FarmId { get; set; }

    public virtual KoiFarm? Farm { get; set; }

    public virtual Trip? Trip { get; set; }
}
