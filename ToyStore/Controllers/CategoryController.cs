using Contracts.Requests;
using BusinessLogic.Services;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Получение информации о всех категориях
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories.Adapt<List<GetCategoryResponse>>());
        }

        /// <summary>
        /// Получение информации о категории по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.Adapt<GetCategoryResponse>());
        }

        /// <summary>
        /// Создание новой категории
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Category
        ///     {
        ///         "categoryName": "Игрушки"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryRequest request)
        {
            var category = request.Adapt<Category>();
            await _categoryService.Create(category);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о категории
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Category
        ///     {
        ///         "categoryID": 1,
        ///         "categoryName": "Игрушки для детей"
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryRequest request)
        {
            var existingCategory = await _categoryService.GetById(request.CategoryID);
            if (existingCategory == null)
            {
                return NotFound();
            }

            var category = request.Adapt<Category>();
            await _categoryService.Update(category);
            return Ok();
        }

        /// <summary>
        /// Удаление категории по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }
    }
}