using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ReturnDetailRepository : RepositoryBase<ReturnDetail>, IReturnDetailRepository
    {
        public ReturnDetailRepository(ToyStoreDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}