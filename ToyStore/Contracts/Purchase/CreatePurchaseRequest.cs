namespace Contracts.Requests
{
    public class CreatePurchaseRequest
    {
        public int SupplierID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}