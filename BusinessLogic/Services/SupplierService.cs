using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SupplierService : ISupplierService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SupplierService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await _repositoryWrapper.Supplier.FindAll();
        }

        public async Task<Supplier> GetById(int id)
        {
            var supplier = await _repositoryWrapper.Supplier
                .FindByCondition(x => x.SupplierId == id);
            return supplier.First();
        }

        public async Task Create(Supplier model)
        {
            await _repositoryWrapper.Supplier.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Supplier model)
        {
            _repositoryWrapper.Supplier.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var supplier = await _repositoryWrapper.Supplier
                .FindByCondition(x => x.SupplierId == id);

            _repositoryWrapper.Supplier.Delete(supplier.First());
            await _repositoryWrapper.Save();
        }
    }
}