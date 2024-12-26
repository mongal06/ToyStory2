using BusinessLogic.Services;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Interfaces;

namespace BankPrikoloff.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        /// <summary>
        /// Получение информации о всех магазинах
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stores = await _storeService.GetAll();
            return Ok(stores.Adapt<List<GetStoreResponse>>());
        }

        /// <summary>
        /// Получение информации о магазине по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var store = await _storeService.GetById(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store.Adapt<GetStoreResponse>());
        }

        /// <summary>
        /// Создание нового магазина
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Store
        ///     {
        ///         "storeName": "Магазин игрушек",
        ///         "address": "ул. Пушкина, д. 10",
        ///         "phone": "1234567890"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateStoreRequest request)
        {
            var store = request.Adapt<Store>();
            await _storeService.Create(store);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о магазине
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Store
        ///     {
        ///         "storeID": 1,
        ///         "storeName": "Магазин игрушек",
        ///         "address": "ул. Пушкина, д. 10",
        ///         "phone": "1234567890"
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStoreRequest request)
        {
            var existingStore = await _storeService.GetById(request.StoreID);
            if (existingStore == null)
            {
                return NotFound();
            }

            var store = request.Adapt<Store>();
            await _storeService.Update(store);
            return Ok();
        }

        /// <summary>
        /// Удаление магазина по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _storeService.Delete(id);
            return Ok();
        }
    }
}