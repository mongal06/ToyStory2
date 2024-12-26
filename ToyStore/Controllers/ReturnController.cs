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
    public class ReturnController : ControllerBase
    {
        private readonly IReturnService _returnService;

        public ReturnController(IReturnService returnService)
        {
            _returnService = returnService;
        }

        /// <summary>
        /// Получение информации о всех возвратах
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var returns = await _returnService.GetAll();
            return Ok(returns.Adapt<List<GetReturnResponse>>());
        }

        /// <summary>
        /// Получение информации о возврате по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnEntity = await _returnService.GetById(id);
            if (returnEntity == null)
            {
                return NotFound();
            }
            return Ok(returnEntity.Adapt<GetReturnResponse>());
        }

        /// <summary>
        /// Создание нового возврата
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Return
        ///     {
        ///         "saleID": 1,
        ///         "returnDate": "2024-01-01T00:00:00",
        ///         "totalAmount": 100.0
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateReturnRequest request)
        {
            var returnEntity = request.Adapt<Return>();
            await _returnService.Create(returnEntity);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о возврате
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Return
        ///     {
        ///         "returnID": 1,
        ///         "saleID": 1,
        ///         "returnDate": "2024-01-01T00:00:00",
        ///         "totalAmount": 120.0
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateReturnRequest request)
        {
            var existingReturn = await _returnService.GetById(request.ReturnID);
            if (existingReturn == null)
            {
                return NotFound();
            }

            var returnEntity = request.Adapt<Return>();
            await _returnService.Update(returnEntity);
            return Ok();
        }

        /// <summary>
        /// Удаление возврата по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _returnService.Delete(id);
            return Ok();
        }
    }
}