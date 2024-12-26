namespace Contracts.Requests
{
    public class CreateWarehouseStockRequest
    {
        public int WarehouseID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}