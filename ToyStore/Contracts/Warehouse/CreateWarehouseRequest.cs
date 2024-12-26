namespace Contracts.Requests
{
    public class CreateWarehouseRequest
    {
        public string WarehouseName { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}