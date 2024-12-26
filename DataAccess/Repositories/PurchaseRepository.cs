using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(ToyStoreDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}