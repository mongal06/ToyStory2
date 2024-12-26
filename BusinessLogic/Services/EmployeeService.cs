using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public EmployeeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _repositoryWrapper.Employee.FindAll();
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _repositoryWrapper.Employee
                .FindByCondition(x => x.EmployeeId == id);
            return employee.First();
        }

        public async Task Create(Employee model)
        {
            await _repositoryWrapper.Employee.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Employee model)
        {
            _repositoryWrapper.Employee.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var employee = await _repositoryWrapper.Employee
                .FindByCondition(x => x.EmployeeId == id);

            _repositoryWrapper.Employee.Delete(employee.First());
            await _repositoryWrapper.Save();
        }
    }
}