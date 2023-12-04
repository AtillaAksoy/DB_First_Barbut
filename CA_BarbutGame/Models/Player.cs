using System;
using System.Collections.Generic;

namespace CA_BarbutGame.Models;

public partial class Player
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int BankId { get; set; }

    public decimal Point { get; set; }

    public virtual Bank? Bank { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
