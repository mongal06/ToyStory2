namespace Contracts.Requests
{
    public class CreateReturnRequest
    {
        public int SaleID { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}