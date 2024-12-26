using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public int? ProductId { get; set; }

    public decimal DiscountPercent { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual Product? Product { get; set; }
}
