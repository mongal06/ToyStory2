using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class WarehouseService : IWarehouseService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public WarehouseService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Warehouse>> GetAll()
        {
            return await _repositoryWrapper.Warehouse.FindAll();
        }

        public async Task<Warehouse> GetById(int id)
        {
            var warehouse = await _repositoryWrapper.Warehouse
                .FindByCondition(x => x.WarehouseId == id);
            return warehouse.First();
        }

        public async Task Create(Warehouse model)
        {
            await _repositoryWrapper.Warehouse.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Warehouse model)
        {
            _repositoryWrapper.Warehouse.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var warehouse = await _repositoryWrapper.Warehouse
                .FindByCondition(x => x.WarehouseId  == id);

            _repositoryWrapper.Warehouse.Delete(warehouse.First());
            await _repositoryWrapper.Save();
        }
    }
}