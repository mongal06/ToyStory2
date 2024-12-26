using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IStoreRepository Store { get; }
        ISupplierRepository Supplier { get; }
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IPurchaseRepository Purchase { get; }
        IPurchaseDetailRepository PurchaseDetail { get; }
        ISaleRepository Sale { get; }
        ISaleDetailRepository SaleDetail { get; }
        IEmployeeRepository Employee { get; }
        ICustomerRepository Customer { get; }
        ICustomerOrderRepository CustomerOrder { get; }
        IOrderDetailRepository OrderDetail { get; }
        IReturnRepository Return { get; }
        IReturnDetailRepository ReturnDetail { get; }
        IDiscountRepository Discount { get; }
        IPromotionRepository Promotion { get; }
        IPromotionProductRepository PromotionProduct { get; }
        IWarehouseRepository Warehouse { get; }
        IWarehouseStockRepository WarehouseStock { get; }
        ITransactionRepository Transaction { get; }
        Task Save();
    }
}