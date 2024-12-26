using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Return
{
    public int ReturnId { get; set; }

    public int? SaleId { get; set; }

    public DateOnly ReturnDate { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual ICollection<ReturnDetail> ReturnDetails { get; set; } = new List<ReturnDetail>();

    public virtual Sale? Sale { get; set; }
}
