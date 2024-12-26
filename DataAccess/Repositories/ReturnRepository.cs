using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ReturnRepository : RepositoryBase<Return>, IReturnRepository
    {
        public ReturnRepository(ToyStoreDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}