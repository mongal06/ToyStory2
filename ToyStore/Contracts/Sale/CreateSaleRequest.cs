namespace Contracts.Requests
{
    public class CreateSaleRequest
    {
        public int StoreID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}