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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Получение информации о всех продуктах
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products.Adapt<List<GetProductResponse>>());
        }

        /// <summary>
        /// Получение информации о продукте по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.Adapt<GetProductResponse>());
        }

        /// <summary>
        /// Создание нового продукта
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Product
        ///     {
        ///         "productName": "Мяч",
        ///         "categoryID": 1,
        ///         "supplierID": 1,
        ///         "price": 100,
        ///         "stockQuantity": 10
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            var product = request.Adapt<Product>();
            await _productService.Create(product);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о продукте
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Product
        ///     {
        ///         "productID": 1,
        ///         "productName": "Мяч",
        ///         "categoryID": 1,
        ///         "supplierID": 1,
        ///         "price": 100,
        ///         "stockQuantity": 10
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductRequest request)
        {
            var existingProduct = await _productService.GetById(request.ProductID);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var product = request.Adapt<Product>();
            await _productService.Update(product);
            return Ok();
        }

        /// <summary>
        /// Удаление продукта по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}