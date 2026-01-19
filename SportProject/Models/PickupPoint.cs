using System;
using System.Collections.Generic;

namespace SportProject.Models;

public partial class PickupPoint
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string NumberHouse { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;
}
