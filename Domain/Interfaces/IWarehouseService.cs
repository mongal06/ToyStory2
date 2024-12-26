using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IWarehouseService
    {
        Task<List<Warehouse>> GetAll();
        Task<Warehouse> GetById(int id);
        Task Create(Warehouse model);
        Task Update(Warehouse model);
        Task Delete(int id);
    }
}