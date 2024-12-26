namespace Contracts.Responses
{
    public class GetSaleResponse
    {
        public int SaleID { get; set; }
        public int StoreID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}