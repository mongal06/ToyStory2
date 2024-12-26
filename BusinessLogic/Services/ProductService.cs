using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProductService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repositoryWrapper.Product.FindAll();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _repositoryWrapper.Product
                .FindByCondition(x => x.ProductId == id);
            return product.First();
        }

        public async Task Create(Product model)
        {
            await _repositoryWrapper.Product.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Product model)
        {
            _repositoryWrapper.Product.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var product = await _repositoryWrapper.Product
                .FindByCondition(x => x.ProductId == id);

            _repositoryWrapper.Product.Delete(product.First());
            await _repositoryWrapper.Save();
        }
    }
}