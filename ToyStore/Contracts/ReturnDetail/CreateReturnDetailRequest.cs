namespace Contracts.Requests
{
    public class CreateReturnDetailRequest
    {
        public int ReturnID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}