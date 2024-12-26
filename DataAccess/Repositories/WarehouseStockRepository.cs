using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class WarehouseStockRepository : RepositoryBase<WarehouseStock>, IWarehouseStockRepository
    {
        public WarehouseStockRepository(ToyStoreDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}