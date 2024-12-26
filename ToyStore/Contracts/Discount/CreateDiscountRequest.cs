namespace Contracts.Requests
{
    public class CreateDiscountRequest
    {
        public int ProductID { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}