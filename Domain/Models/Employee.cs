using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? StoreId { get; set; }

    public string? Position { get; set; }

    public DateOnly HireDate { get; set; }

    public virtual Store? Store { get; set; }
}
