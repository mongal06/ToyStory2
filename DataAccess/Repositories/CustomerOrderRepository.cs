using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CustomerOrderRepository : RepositoryBase<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(ToyStoreDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}