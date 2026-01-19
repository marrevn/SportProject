using System;
using System.Collections.Generic;

namespace SportProject.Models;

public partial class OrdersComposition
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public string IdArticle { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Tovar Tovar { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
