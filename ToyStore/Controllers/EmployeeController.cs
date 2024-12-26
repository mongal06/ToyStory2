using BusinessLogic.Services;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankPrikoloff.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Получение информации о всех сотрудниках
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAll();
            return Ok(employees.Adapt<List<GetEmployeeResponse>>());
        }

        /// <summary>
        /// Получение информации о сотруднике по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee.Adapt<GetEmployeeResponse>());
        }

        /// <summary>
        /// Создание нового сотрудника
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Employee
        ///     {
        ///         "firstName": "Иван",
        ///         "lastName": "Иванов",
        ///         "storeID": 1,
        ///         "position": "Менеджер",
        ///         "hireDate": "2024-01-01T00:00:00"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateEmployeeRequest request)
        {
            var employee = request.Adapt<Employee>();
            await _employeeService.Create(employee);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о сотруднике
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Employee
        ///     {
        ///         "employeeID": 1,
        ///         "firstName": "Иван",
        ///         "lastName": "Иванов",
        ///         "storeID": 1,
        ///         "position": "Старший менеджер",
        ///         "hireDate": "2024-01-01T00:00:00"
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateEmployeeRequest request)
        {
            var existingEmployee = await _employeeService.GetById(request.EmployeeID);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            var employee = request.Adapt<Employee>();
            await _employeeService.Update(employee);
            return Ok();
        }

        /// <summary>
        /// Удаление сотрудника по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.Delete(id);
            return Ok();
        }
    }
}