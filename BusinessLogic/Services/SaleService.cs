using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SaleService : ISaleService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SaleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Sale>> GetAll()
        {
            return await _repositoryWrapper.Sale.FindAll();
        }

        public async Task<Sale> GetById(int id)
        {
            var sale = await _repositoryWrapper.Sale
                .FindByCondition(x => x.SaleId == id);
            return sale.First();
        }

        public async Task Create(Sale model)
        {
            await _repositoryWrapper.Sale.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Sale model)
        {
            _repositoryWrapper.Sale.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var sale = await _repositoryWrapper.Sale
                .FindByCondition(x => x.SaleId == id);

            _repositoryWrapper.Sale.Delete(sale.First());
            await _repositoryWrapper.Save();
        }
    }
}