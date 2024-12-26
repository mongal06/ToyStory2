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
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        /// <summary>
        /// Получение информации о всех продажах
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _saleService.GetAll();
            return Ok(sales.Adapt<List<GetSaleResponse>>());
        }

        /// <summary>
        /// Получение информации о продаже по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await _saleService.GetById(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale.Adapt<GetSaleResponse>());
        }

        /// <summary>
        /// Создание новой продажи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Sale
        ///     {
        ///         "storeID": 1,
        ///         "saleDate": "2024-01-01T00:00:00",
        ///         "totalAmount": 1000.0
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateSaleRequest request)
        {
            var sale = request.Adapt<Sale>();
            await _saleService.Create(sale);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о продаже
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Sale
        ///     {
        ///         "saleID": 1,
        ///         "storeID": 1,
        ///         "saleDate": "2024-01-01T00:00:00",
        ///         "totalAmount": 1200.0
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSaleRequest request)
        {
            var existingSale = await _saleService.GetById(request.SaleID);
            if (existingSale == null)
            {
                return NotFound();
            }

            var sale = request.Adapt<Sale>();
            await _saleService.Update(sale);
            return Ok();
        }

        /// <summary>
        /// Удаление продажи по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _saleService.Delete(id);
            return Ok();
        }
    }
}