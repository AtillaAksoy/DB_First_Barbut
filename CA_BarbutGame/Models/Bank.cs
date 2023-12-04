using System;
using System.Collections.Generic;

namespace CA_BarbutGame.Models;

public partial class Bank
{
    public int Id { get; set; }

    public decimal Money { get; set; }

    public virtual Player IdNavigation { get; set; } = null!;
}
