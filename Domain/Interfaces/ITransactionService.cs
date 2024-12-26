using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAll();
        Task<Transaction> GetById(int id);
        Task Create(Transaction model);
        Task Update(Transaction model);
        Task Delete(int id);
    }
}