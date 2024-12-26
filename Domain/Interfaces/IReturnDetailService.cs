using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReturnDetailService
    {
        Task<List<ReturnDetail>> GetAll();
        Task<ReturnDetail> GetById(int id);
        Task Create(ReturnDetail model);
        Task Update(ReturnDetail model);
        Task Delete(int id);
    }
}