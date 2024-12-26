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
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        /// <summary>
        /// Получение информации о всех акциях
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var promotions = await _promotionService.GetAll();
            return Ok(promotions.Adapt<List<GetPromotionResponse>>());
        }

        /// <summary>
        /// Получение информации об акции по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var promotion = await _promotionService.GetById(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion.Adapt<GetPromotionResponse>());
        }

        /// <summary>
        /// Создание новой акции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Promotion
        ///     {
        ///         "promotionName": "Новогодняя распродажа",
        ///         "startDate": "2024-12-01T00:00:00",
        ///         "endDate": "2024-12-31T23:59:59",
        ///         "description": "Скидки на все товары"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreatePromotionRequest request)
        {
            var promotion = request.Adapt<Promotion>();
            await _promotionService.Create(promotion);
            return Ok();
        }

        /// <summary>
        /// Обновление информации об акции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Promotion
        ///     {
        ///         "promotionID": 1,
        ///         "promotionName": "Новогодняя распродажа",
        ///         "startDate": "2024-12-01T00:00:00",
        ///         "endDate": "2024-12-31T23:59:59",
        ///         "description": "Скидки на все товары до 50%"
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePromotionRequest request)
        {
            var existingPromotion = await _promotionService.GetById(request.PromotionID);
            if (existingPromotion == null)
            {
                return NotFound();
            }

            var promotion = request.Adapt<Promotion>();
            await _promotionService.Update(promotion);
            return Ok();
        }

        /// <summary>
        /// Удаление акции по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _promotionService.Delete(id);
            return Ok();
        }
    }
}