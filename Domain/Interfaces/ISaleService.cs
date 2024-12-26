using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISaleService
    {
        Task<List<Sale>> GetAll();
        Task<Sale> GetById(int id);
        Task Create(Sale model);
        Task Update(Sale model);
        Task Delete(int id);
    }
}