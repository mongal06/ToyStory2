using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ReturnDetail
{
    public int ReturnDetailId { get; set; }

    public int? ReturnId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Return? Return { get; set; }
}
