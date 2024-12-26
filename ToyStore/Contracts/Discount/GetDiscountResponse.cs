namespace Contracts.Responses
{
    public class GetDiscountResponse
    {
        public int DiscountID { get; set; }
        public int ProductID { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}