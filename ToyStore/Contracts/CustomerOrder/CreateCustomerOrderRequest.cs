namespace Contracts.Requests
{
    public class CreateCustomerOrderRequest
    {
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}