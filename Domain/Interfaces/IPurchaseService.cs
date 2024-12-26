using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurchaseService
    {
        Task<List<Purchase>> GetAll();
        Task<Purchase> GetById(int id);
        Task Create(Purchase model);
        Task Update(Purchase model);
        Task Delete(int id);
    }
}