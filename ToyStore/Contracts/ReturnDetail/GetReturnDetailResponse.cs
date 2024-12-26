namespace Contracts.Responses
{
    public class GetReturnDetailResponse
    {
        public int ReturnDetailID { get; set; }
        public int ReturnID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}