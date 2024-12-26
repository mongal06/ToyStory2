using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PromotionProductRepository : RepositoryBase<PromotionProduct>, IPromotionProductRepository
    {
        public PromotionProductRepository(ToyStoreDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}