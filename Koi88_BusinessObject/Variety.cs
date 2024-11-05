﻿using System;
using System.Collections.Generic;

namespace Koi88_BusinessObject;

public partial class Variety
{
    public int VarietyId { get; set; }

    public string? VarietyName { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();

    public virtual ICollection<SpecialVariety> SpecialVarieties { get; set; } = new List<SpecialVariety>();
}
