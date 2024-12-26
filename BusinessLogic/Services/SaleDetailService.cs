using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SaleDetailService : ISaleDetailService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SaleDetailService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<SaleDetail>> GetAll()
        {
            return await _repositoryWrapper.SaleDetail.FindAll();
        }

        public async Task<SaleDetail> GetById(int id)
        {
            var saleDetail = await _repositoryWrapper.SaleDetail
                .FindByCondition(x => x.SaleDetailId == id);
            return saleDetail.First();
        }

        public async Task Create(SaleDetail model)
        {
            await _repositoryWrapper.SaleDetail.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(SaleDetail model)
        {
            _repositoryWrapper.SaleDetail.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var saleDetail = await _repositoryWrapper.SaleDetail
                .FindByCondition(x => x.SaleDetailId == id);

            _repositoryWrapper.SaleDetail.Delete(saleDetail.First());
            await _repositoryWrapper.Save();
        }
    }
}