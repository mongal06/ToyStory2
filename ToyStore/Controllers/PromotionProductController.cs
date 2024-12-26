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
    public class PromotionProductController : ControllerBase
    {
        private readonly IPromotionProductService _promotionProductService;

        public PromotionProductController(IPromotionProductService promotionProductService)
        {
            _promotionProductService = promotionProductService;
        }

        /// <summary>
        /// Получение информации о всех продуктах в акциях
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var promotionProducts = await _promotionProductService.GetAll();
            return Ok(promotionProducts.Adapt<List<GetPromotionProductResponse>>());
        }

        /// <summary>
        /// Получение информации о продукте в акции по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var promotionProduct = await _promotionProductService.GetById(id);
            if (promotionProduct == null)
            {
                return NotFound();
            }
            return Ok(promotionProduct.Adapt<GetPromotionProductResponse>());
        }

        /// <summary>
        /// Создание нового продукта в акции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /PromotionProduct
        ///     {
        ///         "promotionID": 1,
        ///         "productID": 1
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreatePromotionProductRequest request)
        {
            var promotionProduct = request.Adapt<PromotionProduct>();
            await _promotionProductService.Create(promotionProduct);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о продукте в акции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /PromotionProduct
        ///     {
        ///         "promotionProductID": 1,
        ///         "promotionID": 1,
        ///         "productID": 1
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePromotionProductRequest request)
        {
            var existingPromotionProduct = await _promotionProductService.GetById(request.PromotionProductID);
            if (existingPromotionProduct == null)
            {
                return NotFound();
            }

            var promotionProduct = request.Adapt<PromotionProduct>();
            await _promotionProductService.Update(promotionProduct);
            return Ok();
        }

        /// <summary>
        /// Удаление продукта в акции по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _promotionProductService.Delete(id);
            return Ok();
        }
    }
}