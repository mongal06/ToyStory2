using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PromotionProductService : IPromotionProductService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PromotionProductService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PromotionProduct>> GetAll()
        {
            return await _repositoryWrapper.PromotionProduct.FindAll();
        }

        public async Task<PromotionProduct> GetById(int id)
        {
            var promotionProduct = await _repositoryWrapper.PromotionProduct
                .FindByCondition(x => x.PromotionProductId == id);
            return promotionProduct.First();
        }

        public async Task Create(PromotionProduct model)
        {
            await _repositoryWrapper.PromotionProduct.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(PromotionProduct model)
        {
            _repositoryWrapper.PromotionProduct.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var promotionProduct = await _repositoryWrapper.PromotionProduct
                .FindByCondition(x => x.PromotionProductId == id);

            _repositoryWrapper.PromotionProduct.Delete(promotionProduct.First());
            await _repositoryWrapper.Save();
        }
    }
}