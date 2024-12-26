using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class WarehouseStockService : IWarehouseStockService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public WarehouseStockService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<WarehouseStock>> GetAll()
        {
            return await _repositoryWrapper.WarehouseStock.FindAll();
        }

        public async Task<WarehouseStock> GetById(int id)
        {
            var warehouseStock = await _repositoryWrapper.WarehouseStock
                .FindByCondition(x => x.WarehouseStockId == id);
            return warehouseStock.First();
        }

        public async Task Create(WarehouseStock model)
        {
            await _repositoryWrapper.WarehouseStock.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(WarehouseStock model)
        {
            _repositoryWrapper.WarehouseStock.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var warehouseStock = await _repositoryWrapper.WarehouseStock
                .FindByCondition(x => x.WarehouseStockId == id);

            _repositoryWrapper.WarehouseStock.Delete(warehouseStock.First());
            await _repositoryWrapper.Save();
        }
    }
}