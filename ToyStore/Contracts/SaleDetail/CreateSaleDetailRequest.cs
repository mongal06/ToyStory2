namespace Contracts.Requests
{
    public class CreateSaleDetailRequest
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}