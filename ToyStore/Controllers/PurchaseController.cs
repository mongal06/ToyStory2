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
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        /// <summary>
        /// Получение информации о всех закупках
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var purchases = await _purchaseService.GetAll();
            return Ok(purchases.Adapt<List<GetPurchaseResponse>>());
        }

        /// <summary>
        /// Получение информации о закупке по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var purchase = await _purchaseService.GetById(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase.Adapt<GetPurchaseResponse>());
        }

        /// <summary>
        /// Создание новой закупки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Purchase
        ///     {
        ///         "supplierID": 1,
        ///         "purchaseDate": "2024-01-01T00:00:00",
        ///         "totalAmount": 1000.0
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreatePurchaseRequest request)
        {
            var purchase = request.Adapt<Purchase>();
            await _purchaseService.Create(purchase);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о закупке
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Purchase
        ///     {
        ///         "purchaseID": 1,
        ///         "supplierID": 1,
        ///         "purchaseDate": "2024-01-01T00:00:00",
        ///         "totalAmount": 1200.0
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePurchaseRequest request)
        {
            var existingPurchase = await _purchaseService.GetById(request.PurchaseID);
            if (existingPurchase == null)
            {
                return NotFound();
            }

            var purchase = request.Adapt<Purchase>();
            await _purchaseService.Update(purchase);
            return Ok();
        }

        /// <summary>
        /// Удаление закупки по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _purchaseService.Delete(id);
            return Ok();
        }
    }
}