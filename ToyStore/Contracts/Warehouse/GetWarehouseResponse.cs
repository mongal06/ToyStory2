namespace Contracts.Responses
{
    public class GetWarehouseResponse
    {
        public int WarehouseID { get; set; }
        public string WarehouseName { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}