using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public OrderDetailService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<OrderDetail>> GetAll()
        {
            return await _repositoryWrapper.OrderDetail.FindAll();
        }

        public async Task<OrderDetail> GetById(int id)
        {
            var orderDetail = await _repositoryWrapper.OrderDetail
                .FindByCondition(x => x.OrderDetailId == id);
            return orderDetail.First();
        }

        public async Task Create(OrderDetail model)
        {
            await _repositoryWrapper.OrderDetail.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(OrderDetail model)
        {
            _repositoryWrapper.OrderDetail.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var orderDetail = await _repositoryWrapper.OrderDetail
                .FindByCondition(x => x.OrderDetailId == id);

            _repositoryWrapper.OrderDetail.Delete(orderDetail.First());
            await _repositoryWrapper.Save();
        }
    }
}