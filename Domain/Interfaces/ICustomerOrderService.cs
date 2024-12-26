using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerOrderService
    {
        Task<List<CustomerOrder>> GetAll();
        Task<CustomerOrder> GetById(int id);
        Task Create(CustomerOrder model);
        Task Update(CustomerOrder model);
        Task Delete(int id);
    }
}