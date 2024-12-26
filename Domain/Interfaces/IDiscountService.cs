using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDiscountService
    {
        Task<List<Discount>> GetAll();
        Task<Discount> GetById(int id);
        Task Create(Discount model);
        Task Update(Discount model);
        Task Delete(int id);
    }
}