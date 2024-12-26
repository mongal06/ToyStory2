using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CustomerOrderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<CustomerOrder>> GetAll()
        {
            return await _repositoryWrapper.CustomerOrder.FindAll();
        }

        public async Task<CustomerOrder> GetById(int id)
        {
            var order = await _repositoryWrapper.CustomerOrder
                .FindByCondition(x => x.OrderId == id);
            return order.First();
        }

        public async Task Create(CustomerOrder model)
        {
            await _repositoryWrapper.CustomerOrder.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(CustomerOrder model)
        {
            _repositoryWrapper.CustomerOrder.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var order = await _repositoryWrapper.CustomerOrder
                .FindByCondition(x => x.OrderId == id);

            _repositoryWrapper.CustomerOrder.Delete(order.First());
            await _repositoryWrapper.Save();
        }
    }
}