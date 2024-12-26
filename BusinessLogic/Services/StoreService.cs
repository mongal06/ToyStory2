using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class StoreService : IStoreService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StoreService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Store>> GetAll()
        {
            return await _repositoryWrapper.Store.FindAll();
        }

        public async Task<Store> GetById(int id)
        {
            var store = await _repositoryWrapper.Store
                .FindByCondition(x => x.StoreId == id);
            return store.First();
        }

        public async Task Create(Store model)
        {
            await _repositoryWrapper.Store.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Store model)
        {
            _repositoryWrapper.Store.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var store = await _repositoryWrapper.Store
                .FindByCondition(x => x.StoreId == id);

            _repositoryWrapper.Store.Delete(store.First());
            await _repositoryWrapper.Save();
        }
    }
}