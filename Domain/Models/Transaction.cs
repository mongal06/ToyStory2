using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public DateOnly TransactionDate { get; set; }

    public string TransactionType { get; set; } = null!;

    public decimal Amount { get; set; }

    public string? Description { get; set; }
}
