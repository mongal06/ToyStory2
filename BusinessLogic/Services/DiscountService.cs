using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class DiscountService : IDiscountService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public DiscountService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Discount>> GetAll()
        {
            return await _repositoryWrapper.Discount.FindAll();
        }

        public async Task<Discount> GetById(int id)
        {
            var discount = await _repositoryWrapper.Discount
                .FindByCondition(x => x.DiscountId == id);
            return discount.First();
        }

        public async Task Create(Discount model)
        {
            await _repositoryWrapper.Discount.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Discount model)
        {
            _repositoryWrapper.Discount.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var discount = await _repositoryWrapper.Discount
                .FindByCondition(x => x.DiscountId == id);

            _repositoryWrapper.Discount.Delete(discount.First());
            await _repositoryWrapper.Save();
        }
    }
}