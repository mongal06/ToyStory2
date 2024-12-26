using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurchaseDetailService
    {
        Task<List<PurchaseDetail>> GetAll();
        Task<PurchaseDetail> GetById(int id);
        Task Create(PurchaseDetail model);
        Task Update(PurchaseDetail model);
        Task Delete(int id);
    }
}