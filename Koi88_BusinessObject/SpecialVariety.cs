using System;
using System.Collections.Generic;

namespace Koi88_BusinessObject;

public partial class SpecialVariety
{
    public int SpecialVarietyId { get; set; }

    public int? FarmId { get; set; }

    public int? VarietyId { get; set; }

    public virtual KoiFarm? Farm { get; set; }

    public virtual Variety? Variety { get; set; }
}
