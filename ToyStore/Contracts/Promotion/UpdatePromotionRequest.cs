namespace Contracts.Requests
{
    public class UpdatePromotionRequest
    {
        public int PromotionID { get; set; }
        public string PromotionName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = null!;
    }
}