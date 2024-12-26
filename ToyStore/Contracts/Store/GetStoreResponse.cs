namespace Contracts.Responses
{
    public class GetStoreResponse
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}