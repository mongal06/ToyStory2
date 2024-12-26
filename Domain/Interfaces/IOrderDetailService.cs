using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAll();
        Task<OrderDetail> GetById(int id);
        Task Create(OrderDetail model);
        Task Update(OrderDetail model);
        Task Delete(int id);
    }
}