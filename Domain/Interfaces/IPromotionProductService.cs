using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPromotionProductService
    {
        Task<List<PromotionProduct>> GetAll();
        Task<PromotionProduct> GetById(int id);
        Task Create(PromotionProduct model);
        Task Update(PromotionProduct model);
        Task Delete(int id);
    }
}