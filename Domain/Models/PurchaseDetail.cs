using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PurchaseDetail
{
    public int PurchaseDetailId { get; set; }

    public int? PurchaseId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Purchase? Purchase { get; set; }
}
