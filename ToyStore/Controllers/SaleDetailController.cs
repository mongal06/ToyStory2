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
    public class SaleDetailController : ControllerBase
    {
        private readonly ISaleDetailService _saleDetailService;

        public SaleDetailController(ISaleDetailService saleDetailService)
        {
            _saleDetailService = saleDetailService;
        }

        /// <summary>
        /// Получение информации о всех деталях продаж
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var saleDetails = await _saleDetailService.GetAll();
            return Ok(saleDetails.Adapt<List<GetSaleDetailResponse>>());
        }

        /// <summary>
        /// Получение информации о детали продажи по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var saleDetail = await _saleDetailService.GetById(id);
            if (saleDetail == null)
            {
                return NotFound();
            }
            return Ok(saleDetail.Adapt<GetSaleDetailResponse>());
        }

        /// <summary>
        /// Создание новой детали продажи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /SaleDetail
        ///     {
        ///         "saleID": 1,
        ///         "productID": 1,
        ///         "quantity": 2,
        ///         "unitPrice": 50.0
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateSaleDetailRequest request)
        {
            var saleDetail = request.Adapt<SaleDetail>();
            await _saleDetailService.Create(saleDetail);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о детали продажи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /SaleDetail
        ///     {
        ///         "saleDetailID": 1,
        ///         "saleID": 1,
        ///         "productID": 1,
        ///         "quantity": 3,
        ///         "unitPrice": 60.0
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSaleDetailRequest request)
        {
            var existingSaleDetail = await _saleDetailService.GetById(request.SaleDetailID);
            if (existingSaleDetail == null)
            {
                return NotFound();
            }

            var saleDetail = request.Adapt<SaleDetail>();
            await _saleDetailService.Update(saleDetail);
            return Ok();
        }

        /// <summary>
        /// Удаление детали продажи по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _saleDetailService.Delete(id);
            return Ok();
        }
    }
}