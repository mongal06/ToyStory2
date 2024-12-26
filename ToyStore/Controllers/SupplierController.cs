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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        /// <summary>
        /// Получение информации о всех поставщиках
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierService.GetAll();
            return Ok(suppliers.Adapt<List<GetSupplierResponse>>());
        }

        /// <summary>
        /// Получение информации о поставщике по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierService.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier.Adapt<GetSupplierResponse>());
        }

        /// <summary>
        /// Создание нового поставщика
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Supplier
        ///     {
        ///         "supplierName": "Поставщик игрушек",
        ///         "contactName": "Иван Иванов",
        ///         "phone": "1234567890",
        ///         "email": "supplier@example.com"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateSupplierRequest request)
        {
            var supplier = request.Adapt<Supplier>();
            await _supplierService.Create(supplier);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о поставщике
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Supplier
        ///     {
        ///         "supplierID": 1,
        ///         "supplierName": "Поставщик игрушек",
        ///         "contactName": "Иван Иванов",
        ///         "phone": "1234567890",
        ///         "email": "supplier@example.com"
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSupplierRequest request)
        {
            var existingSupplier = await _supplierService.GetById(request.SupplierID);
            if (existingSupplier == null)
            {
                return NotFound();
            }

            var supplier = request.Adapt<Supplier>();
            await _supplierService.Update(supplier);
            return Ok();
        }

        /// <summary>
        /// Удаление поставщика по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _supplierService.Delete(id);
            return Ok();
        }
    }
}