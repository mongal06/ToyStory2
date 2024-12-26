namespace Contracts.Requests
{
    public class UpdateCategoryRequest
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}