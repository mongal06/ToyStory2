namespace Contracts.Requests
{
    public class UpdateSaleDetailRequest
    {
        public int SaleDetailID { get; set; }
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}