using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ReturnDetailService : IReturnDetailService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ReturnDetailService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ReturnDetail>> GetAll()
        {
            return await _repositoryWrapper.ReturnDetail.FindAll();
        }

        public async Task<ReturnDetail> GetById(int id)
        {
            var returnDetail = await _repositoryWrapper.ReturnDetail
                .FindByCondition(x => x.ReturnDetailId == id);
            return returnDetail.First();
        }

        public async Task Create(ReturnDetail model)
        {
            await _repositoryWrapper.ReturnDetail.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(ReturnDetail model)
        {
            _repositoryWrapper.ReturnDetail.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var returnDetail = await _repositoryWrapper.ReturnDetail
                .FindByCondition(x => x.ReturnDetailId == id);

            _repositoryWrapper.ReturnDetail.Delete(returnDetail.First());
            await _repositoryWrapper.Save();
        }
    }
}