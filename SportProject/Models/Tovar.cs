using System;
using System.Collections.Generic;

namespace SportProject.Models;

public partial class Tovar
{
    public string Article { get; set; } = null!;

    public int IdTovar { get; set; }

    public int IdCategory { get; set; }

    public int IdSupplier { get; set; }

    public int IdManufacturer { get; set; }

    public decimal Price { get; set; }

    public string Unit { get; set; } = null!;

    public int Discount { get; set; }

    public int CountTovars { get; set; }

    public string Descreption { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual Good Good { get; set; } = null!;

    public virtual ICollection<OrdersComposition> OrdersCompositions { get; set; } = new List<OrdersComposition>();
}
