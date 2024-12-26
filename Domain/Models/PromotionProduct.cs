using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PromotionProduct
{
    public int PromotionProductId { get; set; }

    public int? PromotionId { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Promotion? Promotion { get; set; }
}
