using System;
using System.Collections.Generic;

namespace SportProject.Models;

public partial class User
{
    public int Id { get; set; }

    public short IdRole { get; set; }

    public string Fio { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
