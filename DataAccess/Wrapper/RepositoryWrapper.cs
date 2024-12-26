using Domain.Interfaces;
using Domain.Models;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ToyStoreDbContext _repoContext;
        private IStoreRepository _store;
        private ISupplierRepository _supplier;
        private ICategoryRepository _category;
        private IProductRepository _product;
        private IPurchaseRepository _purchase;
        private IPurchaseDetailRepository _purchaseDetail;
        private ISaleRepository _sale;
        private ISaleDetailRepository _saleDetail;
        private IEmployeeRepository _employee;
        private ICustomerRepository _customer;
        private ICustomerOrderRepository _customerOrder;
        private IOrderDetailRepository _orderDetail;
        private IReturnRepository _return;
        private IReturnDetailRepository _returnDetail;
        private IDiscountRepository _discount;
        private IPromotionRepository _promotion;
        private IPromotionProductRepository _promotionProduct;
        private IWarehouseRepository _warehouse;
        private IWarehouseStockRepository _warehouseStock;
        private ITransactionRepository _transaction;

        public RepositoryWrapper(ToyStoreDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IStoreRepository Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new StoreRepository(_repoContext);
                }
                return _store;
            }
        }

        public ISupplierRepository Supplier
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new SupplierRepository(_repoContext);
                }
                return _supplier;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }
                return _category;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_repoContext);
                }
                return _product;
            }
        }

        public IPurchaseRepository Purchase
        {
            get
            {
                if (_purchase == null)
                {
                    _purchase = new PurchaseRepository(_repoContext);
                }
                return _purchase;
            }
        }

        public IPurchaseDetailRepository PurchaseDetail
        {
            get
            {
                if (_purchaseDetail == null)
                {
                    _purchaseDetail = new PurchaseDetailRepository(_repoContext);
                }
                return _purchaseDetail;
            }
        }

        public ISaleRepository Sale
        {
            get
            {
                if (_sale == null)
                {
                    _sale = new SaleRepository(_repoContext);
                }
                return _sale;
            }
        }

        public ISaleDetailRepository SaleDetail
        {
            get
            {
                if (_saleDetail == null)
                {
                    _saleDetail = new SaleDetailRepository(_repoContext);
                }
                return _saleDetail;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }
                return _employee;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }
                return _customer;
            }
        }

        public ICustomerOrderRepository CustomerOrder
        {
            get
            {
                if (_customerOrder == null)
                {
                    _customerOrder = new CustomerOrderRepository(_repoContext);
                }
                return _customerOrder;
            }
        }

        public IOrderDetailRepository OrderDetail
        {
            get
            {
                if (_orderDetail == null)
                {
                    _orderDetail = new OrderDetailRepository(_repoContext);
                }
                return _orderDetail;
            }
        }

        public IReturnRepository Return
        {
            get
            {
                if (_return == null)
                {
                    _return = new ReturnRepository(_repoContext);
                }
                return _return;
            }
        }

        public IReturnDetailRepository ReturnDetail
        {
            get
            {
                if (_returnDetail == null)
                {
                    _returnDetail = new ReturnDetailRepository(_repoContext);
                }
                return _returnDetail;
            }
        }

        public IDiscountRepository Discount
        {
            get
            {
                if (_discount == null)
                {
                    _discount = new DiscountRepository(_repoContext);
                }
                return _discount;
            }
        }

        public IPromotionRepository Promotion
        {
            get
            {
                if (_promotion == null)
                {
                    _promotion = new PromotionRepository(_repoContext);
                }
                return _promotion;
            }
        }

        public IPromotionProductRepository PromotionProduct
        {
            get
            {
                if (_promotionProduct == null)
                {
                    _promotionProduct = new PromotionProductRepository(_repoContext);
                }
                return _promotionProduct;
            }
        }

        public IWarehouseRepository Warehouse
        {
            get
            {
                if (_warehouse == null)
                {
                    _warehouse = new WarehouseRepository(_repoContext);
                }
                return _warehouse;
            }
        }

        public IWarehouseStockRepository WarehouseStock
        {
            get
            {
                if (_warehouseStock == null)
                {
                    _warehouseStock = new WarehouseStockRepository(_repoContext);
                }
                return _warehouseStock;
            }
        }

        public ITransactionRepository Transaction
        {
            get
            {
                if (_transaction == null)
                {
                    _transaction = new TransactionRepository(_repoContext);
                }
                return _transaction;
            }
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}