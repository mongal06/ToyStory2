using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TransactionService : ITransactionService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TransactionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Transaction>> GetAll()
        {
            return await _repositoryWrapper.Transaction.FindAll();
        }

        public async Task<Transaction> GetById(int id)
        {
            var transaction = await _repositoryWrapper.Transaction
                .FindByCondition(x => x.TransactionId == id);
            return transaction.First();
        }

        public async Task Create(Transaction model)
        {
            await _repositoryWrapper.Transaction.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Transaction model)
        {
            _repositoryWrapper.Transaction.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var transaction = await _repositoryWrapper.Transaction
                .FindByCondition(x => x.TransactionId == id);

            _repositoryWrapper.Transaction.Delete(transaction.First());
            await _repositoryWrapper.Save();
        }
    }
}