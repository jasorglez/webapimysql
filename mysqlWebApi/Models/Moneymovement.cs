using System;
using System.Collections.Generic;

namespace mysqlWebApi.Models;

public partial class Moneymovement
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public int? Tipomovimiento { get; set; }

    public string? Reference { get; set; }

    public string? Description { get; set; }

    public float? Amount { get; set; }

    public string? Status { get; set; }

    public short? Active { get; set; }

    public virtual Typemovement? TipomovimientoNavigation { get; set; }
}
