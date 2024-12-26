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
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        /// <summary>
        /// Получение информации о всех скидках
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var discounts = await _discountService.GetAll();
            return Ok(discounts.Adapt<List<GetDiscountResponse>>());
        }

        /// <summary>
        /// Получение информации о скидке по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountService.GetById(id);
            if (discount == null)
            {
                return NotFound();
            }
            return Ok(discount.Adapt<GetDiscountResponse>());
        }

        /// <summary>
        /// Создание новой скидки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Discount
        ///     {
        ///         "productID": 1,
        ///         "discountPercent": 10.0,
        ///         "startDate": "2024-01-01T00:00:00",
        ///         "endDate": "2024-12-31T23:59:59"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateDiscountRequest request)
        {
            var discount = request.Adapt<Discount>();
            await _discountService.Create(discount);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о скидке
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Discount
        ///     {
        ///         "discountID": 1,
        ///         "productID": 1,
        ///         "discountPercent": 15.0,
        ///         "startDate": "2024-01-01T00:00:00",
        ///         "endDate": "2024-12-31T23:59:59"
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDiscountRequest request)
        {
            var existingDiscount = await _discountService.GetById(request.DiscountID);
            if (existingDiscount == null)
            {
                return NotFound();
            }

            var discount = request.Adapt<Discount>();
            await _discountService.Update(discount);
            return Ok();
        }

        /// <summary>
        /// Удаление скидки по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountService.Delete(id);
            return Ok();
        }
    }
}