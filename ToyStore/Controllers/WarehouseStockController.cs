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
    public class WarehouseStockController : ControllerBase
    {
        private readonly IWarehouseStockService _warehouseStockService;

        public WarehouseStockController(IWarehouseStockService warehouseStockService)
        {
            _warehouseStockService = warehouseStockService;
        }

        /// <summary>
        /// Получение информации о всех запасах на складах
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var warehouseStocks = await _warehouseStockService.GetAll();
            return Ok(warehouseStocks.Adapt<List<GetWarehouseStockResponse>>());
        }

        /// <summary>
        /// Получение информации о запасе на складе по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var warehouseStock = await _warehouseStockService.GetById(id);
            if (warehouseStock == null)
            {
                return NotFound();
            }
            return Ok(warehouseStock.Adapt<GetWarehouseStockResponse>());
        }

        /// <summary>
        /// Создание нового запаса на складе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /WarehouseStock
        ///     {
        ///         "warehouseID": 1,
        ///         "productID": 1,
        ///         "quantity": 100
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateWarehouseStockRequest request)
        {
            var warehouseStock = request.Adapt<WarehouseStock>();
            await _warehouseStockService.Create(warehouseStock);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о запасе на складе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /WarehouseStock
        ///     {
        ///         "warehouseStockID": 1,
        ///         "warehouseID": 1,
        ///         "productID": 1,
        ///         "quantity": 150
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateWarehouseStockRequest request)
        {
            var existingWarehouseStock = await _warehouseStockService.GetById(request.WarehouseStockID);
            if (existingWarehouseStock == null)
            {
                return NotFound();
            }

            var warehouseStock = request.Adapt<WarehouseStock>();
            await _warehouseStockService.Update(warehouseStock);
            return Ok();
        }

        /// <summary>
        /// Удаление запаса на складе по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _warehouseStockService.Delete(id);
            return Ok();
        }
    }
}