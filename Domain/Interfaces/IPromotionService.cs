using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPromotionService
    {
        Task<List<Promotion>> GetAll();
        Task<Promotion> GetById(int id);
        Task Create(Promotion model);
        Task Update(Promotion model);
        Task Delete(int id);
    }
}