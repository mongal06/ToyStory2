namespace Contracts.Requests
{
    public class UpdatePurchaseRequest
    {
        public int PurchaseID { get; set; }
        public int SupplierID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}