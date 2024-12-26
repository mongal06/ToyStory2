using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CustomerOrder
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
