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
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        /// <summary>
        /// Получение информации о всех складах
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var warehouses = await _warehouseService.GetAll();
            return Ok(warehouses.Adapt<List<GetWarehouseResponse>>());
        }

        /// <summary>
        /// Получение информации о складе по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var warehouse = await _warehouseService.GetById(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse.Adapt<GetWarehouseResponse>());
        }

        /// <summary>
        /// Создание нового склада
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Warehouse
        ///     {
        ///         "warehouseName": "Склад игрушек",
        ///         "address": "ул. Ленина, д. 5"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateWarehouseRequest request)
        {
            var warehouse = request.Adapt<Warehouse>();
            await _warehouseService.Create(warehouse);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о складе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Warehouse
        ///     {
        ///         "warehouseID": 1,
        ///         "warehouseName": "Склад игрушек",
        ///         "address": "ул. Ленина, д. 5"
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateWarehouseRequest request)
        {
            var existingWarehouse = await _warehouseService.GetById(request.WarehouseID);
            if (existingWarehouse == null)
            {
                return NotFound();
            }

            var warehouse = request.Adapt<Warehouse>();
            await _warehouseService.Update(warehouse);
            return Ok();
        }

        /// <summary>
        /// Удаление склада по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _warehouseService.Delete(id);
            return Ok();
        }
    }
}