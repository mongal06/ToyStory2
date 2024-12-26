using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SaleDetailRepository : RepositoryBase<SaleDetail>, ISaleDetailRepository
    {
        public SaleDetailRepository(ToyStoreDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}