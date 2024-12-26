using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PurchaseDetailRepository : RepositoryBase<PurchaseDetail>, IPurchaseDetailRepository
    {
        public PurchaseDetailRepository(ToyStoreDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}