using System;
using System.Collections.Generic;

namespace SportProject.Models;

public partial class Measure
{
    public int Id { get; set; }

    public string MeasureName { get; set; } = null!;

    public virtual ICollection<Tovar> Tovars { get; set; } = new List<Tovar>();
}
