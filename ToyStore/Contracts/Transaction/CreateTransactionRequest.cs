namespace Contracts.Requests
{
    public class CreateTransactionRequest
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
    }
}