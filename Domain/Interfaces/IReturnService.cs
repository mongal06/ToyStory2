using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReturnService
    {
        Task<List<Return>> GetAll();
        Task<Return> GetById(int id);
        Task Create(Return model);
        Task Update(Return model);
        Task Delete(int id);
    }
}