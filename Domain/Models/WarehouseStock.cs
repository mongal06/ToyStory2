using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class WarehouseStock
{
    public int WarehouseStockId { get; set; }

    public int? WarehouseId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
