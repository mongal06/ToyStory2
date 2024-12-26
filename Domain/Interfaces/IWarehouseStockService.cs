using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IWarehouseStockService
    {
        Task<List<WarehouseStock>> GetAll();
        Task<WarehouseStock> GetById(int id);
        Task Create(WarehouseStock model);
        Task Update(WarehouseStock model);
        Task Delete(int id);
    }
}