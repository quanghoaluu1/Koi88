﻿using System;
using System.Collections.Generic;

namespace Koi88_BusinessObject;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? Rating { get; set; }

    public string? Comments { get; set; }

    public int? CustomerId { get; set; }

    public string? Status { get; set; }

    public DateOnly? Feedbackdate { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Customer? Customer { get; set; }
}
