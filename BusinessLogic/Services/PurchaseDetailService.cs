using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PurchaseDetailService : IPurchaseDetailService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PurchaseDetailService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PurchaseDetail>> GetAll()
        {
            return await _repositoryWrapper.PurchaseDetail.FindAll();
        }

        public async Task<PurchaseDetail> GetById(int id)
        {
            var purchaseDetail = await _repositoryWrapper.PurchaseDetail
                .FindByCondition(x => x.PurchaseDetailId == id);
            return purchaseDetail.First();
        }

        public async Task Create(PurchaseDetail model)
        {
            await _repositoryWrapper.PurchaseDetail.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(PurchaseDetail model)
        {
            _repositoryWrapper.PurchaseDetail.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var purchaseDetail = await _repositoryWrapper.PurchaseDetail
                .FindByCondition(x => x.PurchaseDetailId == id);

            _repositoryWrapper.PurchaseDetail.Delete(purchaseDetail.First());
            await _repositoryWrapper.Save();
        }
    }
}