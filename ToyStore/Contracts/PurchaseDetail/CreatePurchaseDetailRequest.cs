namespace Contracts.Requests
{
    public class CreatePurchaseDetailRequest
    {
        public int PurchaseID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}