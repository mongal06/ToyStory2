using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task Create(Employee model);
        Task Update(Employee model);
        Task Delete(int id);
    }
}