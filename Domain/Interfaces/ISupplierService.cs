using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetAll();
        Task<Supplier> GetById(int id);
        Task Create(Supplier model);
        Task Update(Supplier model);
        Task Delete(int id);
    }
}