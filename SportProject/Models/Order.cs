using System;
using System.Collections.Generic;

namespace SportProject.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly DateOrder { get; set; }

    public DateOnly DateDelivery { get; set; }

    public int IdPickupPoint { get; set; }

    public int IdUser { get; set; }

    public int Code { get; set; }

    public int IdStatus { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<OrdersComposition> OrdersCompositions { get; set; } = new List<OrdersComposition>();
}
