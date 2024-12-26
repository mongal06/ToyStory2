using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStoreService
    {
        Task<List<Store>> GetAll();
        Task<Store> GetById(int id);
        Task Create(Store model);
        Task Update(Store model);
        Task Delete(int id);
    }
}