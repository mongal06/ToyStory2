namespace Contracts.Responses
{
    public class GetPurchaseResponse
    {
        public int PurchaseID { get; set; }
        public int SupplierID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}