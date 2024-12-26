namespace Contracts.Responses
{
    public class GetReturnResponse
    {
        public int ReturnID { get; set; }
        public int SaleID { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}