namespace Contracts.Requests
{
    public class UpdateWarehouseStockRequest
    {
        public int WarehouseStockID { get; set; }
        public int WarehouseID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}