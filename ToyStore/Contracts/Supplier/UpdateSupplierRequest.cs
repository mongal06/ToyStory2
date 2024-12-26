namespace Contracts.Requests
{
    public class UpdateSupplierRequest
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; } = null!;
        public string ContactName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}