namespace Contracts.Requests
{
    public class UpdatePromotionProductRequest
    {
        public int PromotionProductID { get; set; }
        public int PromotionID { get; set; }
        public int ProductID { get; set; }
    }
}