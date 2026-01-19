using System;
using System.Collections.Generic;

namespace SportProject.Models;

public partial class OrdersComposition
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public string IdArticle { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Tovar IdArticleNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
