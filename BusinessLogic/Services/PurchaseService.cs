using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PurchaseService : IPurchaseService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PurchaseService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Purchase>> GetAll()
        {
            return await _repositoryWrapper.Purchase.FindAll();
        }

        public async Task<Purchase> GetById(int id)
        {
            var purchase = await _repositoryWrapper.Purchase
                .FindByCondition(x => x.PurchaseId == id);
            return purchase.First();
        }

        public async Task Create(Purchase model)
        {
            await _repositoryWrapper.Purchase.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Purchase model)
        {
            _repositoryWrapper.Purchase.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var purchase = await _repositoryWrapper.Purchase
                .FindByCondition(x => x.PurchaseId == id);

            _repositoryWrapper.Purchase.Delete(purchase.First());
            await _repositoryWrapper.Save();
        }
    }
}