using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int? StoreId { get; set; }

    public DateOnly SaleDate { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual Store? Store { get; set; }
}
