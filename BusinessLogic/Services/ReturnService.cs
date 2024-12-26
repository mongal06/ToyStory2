using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ReturnService : IReturnService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ReturnService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Return>> GetAll()
        {
            return await _repositoryWrapper.Return.FindAll();
        }

        public async Task<Return> GetById(int id)
        {
            var returnEntity = await _repositoryWrapper.Return
                .FindByCondition(x => x.ReturnId == id);
            return returnEntity.First();
        }

        public async Task Create(Return model)
        {
            await _repositoryWrapper.Return.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Return model)
        {
            _repositoryWrapper.Return.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var returnEntity = await _repositoryWrapper.Return
                .FindByCondition(x => x.ReturnId == id);

            _repositoryWrapper.Return.Delete(returnEntity.First());
            await _repositoryWrapper.Save();
        }
    }
}