using System;
using System.Collections.Generic;

namespace SportProject.Models;

public partial class Good
{
    public int Id { get; set; }

    public string GoodName { get; set; } = null!;

    public virtual ICollection<Tovar> Tovars { get; set; } = new List<Tovar>();
}
