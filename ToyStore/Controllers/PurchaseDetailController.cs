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
    public class PurchaseDetailController : ControllerBase
    {
        private readonly IPurchaseDetailService _purchaseDetailService;

        public PurchaseDetailController(IPurchaseDetailService purchaseDetailService)
        {
            _purchaseDetailService = purchaseDetailService;
        }

        /// <summary>
        /// Получение информации о всех деталях закупок
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var purchaseDetails = await _purchaseDetailService.GetAll();
            return Ok(purchaseDetails.Adapt<List<GetPurchaseDetailResponse>>());
        }

        /// <summary>
        /// Получение информации о детали закупки по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var purchaseDetail = await _purchaseDetailService.GetById(id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }
            return Ok(purchaseDetail.Adapt<GetPurchaseDetailResponse>());
        }

        /// <summary>
        /// Создание новой детали закупки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /PurchaseDetail
        ///     {
        ///         "purchaseID": 1,
        ///         "productID": 1,
        ///         "quantity": 10,
        ///         "unitPrice": 50.0
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreatePurchaseDetailRequest request)
        {
            var purchaseDetail = request.Adapt<PurchaseDetail>();
            await _purchaseDetailService.Create(purchaseDetail);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о детали закупки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /PurchaseDetail
        ///     {
        ///         "purchaseDetailID": 1,
        ///         "purchaseID": 1,
        ///         "productID": 1,
        ///         "quantity": 15,
        ///         "unitPrice": 55.0
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePurchaseDetailRequest request)
        {
            var existingPurchaseDetail = await _purchaseDetailService.GetById(request.PurchaseDetailID);
            if (existingPurchaseDetail == null)
            {
                return NotFound();
            }

            var purchaseDetail = request.Adapt<PurchaseDetail>();
            await _purchaseDetailService.Update(purchaseDetail);
            return Ok();
        }

        /// <summary>
        /// Удаление детали закупки по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _purchaseDetailService.Delete(id);
            return Ok();
        }
    }
}