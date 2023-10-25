using System;
using System.Collections.Generic;

namespace mysqlWebApi.Models;

public partial class Typemovement
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public short Active { get; set; }

    public virtual ICollection<Moneymovement> Moneymovements { get; set; } = new List<Moneymovement>();
}
