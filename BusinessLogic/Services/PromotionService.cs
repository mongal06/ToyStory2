using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PromotionService : IPromotionService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PromotionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Promotion>> GetAll()
        {
            return await _repositoryWrapper.Promotion.FindAll();
        }

        public async Task<Promotion> GetById(int id)
        {
            var promotion = await _repositoryWrapper.Promotion
                .FindByCondition(x => x.PromotionId == id);
            return promotion.First();
        }

        public async Task Create(Promotion model)
        {
            await _repositoryWrapper.Promotion.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Promotion model)
        {
            _repositoryWrapper.Promotion.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var promotion = await _repositoryWrapper.Promotion
                .FindByCondition(x => x.PromotionId == id);

            _repositoryWrapper.Promotion.Delete(promotion.First());
            await _repositoryWrapper.Save();
        }
    }
}