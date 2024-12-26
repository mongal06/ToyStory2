using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
