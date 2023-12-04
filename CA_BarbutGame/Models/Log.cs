using System;
using System.Collections.Generic;

namespace CA_BarbutGame.Models;

public partial class Log
{
    public int Id { get; set; }

    public int PlayerId { get; set; }

    public decimal Amount { get; set; }

    public short PlayerDice { get; set; }

    public short PcDice { get; set; }

    public string Winner { get; set; } = null!;

    public string Loser { get; set; } = null!;

    public decimal? PlayerEarnings { get; set; }

    public decimal? PlayerLoss { get; set; }

    public decimal PlayerCurrentBalance { get; set; }

    public DateTime DateTime { get; set; }

    public virtual Player Player { get; set; } = null!;
}
