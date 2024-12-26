namespace Contracts.Requests
{
    public class CreateStoreRequest
    {
        public string StoreName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}