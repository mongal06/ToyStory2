namespace Contracts.Responses
{
    public class GetCategoryResponse
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}