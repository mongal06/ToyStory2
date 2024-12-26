using System;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISaleDetailService
    {
        Task<List<SaleDetail>> GetAll();
        Task<SaleDetail> GetById(int id);
        Task Create(SaleDetail model);
        Task Update(SaleDetail model);
        Task Delete(int id);
    }
}