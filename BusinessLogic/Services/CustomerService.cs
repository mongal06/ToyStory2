using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CustomerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _repositoryWrapper.Customer.FindAll();
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _repositoryWrapper.Customer
                .FindByCondition(x => x.CustomerId == id);
            return customer.First();
        }

        public async Task Create(Customer model)
        {
            await _repositoryWrapper.Customer.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Customer model)
        {
            _repositoryWrapper.Customer.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var customer = await _repositoryWrapper.Customer
                .FindByCondition(x => x.CustomerId == id);

            _repositoryWrapper.Customer.Delete(customer.First());
            await _repositoryWrapper.Save();
        }
    }
}