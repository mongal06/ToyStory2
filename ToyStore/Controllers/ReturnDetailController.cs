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
    public class ReturnDetailController : ControllerBase
    {
        private readonly IReturnDetailService _returnDetailService;

        public ReturnDetailController(IReturnDetailService returnDetailService)
        {
            _returnDetailService = returnDetailService;
        }

        /// <summary>
        /// Получение информации о всех деталях возвратов
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var returnDetails = await _returnDetailService.GetAll();
            return Ok(returnDetails.Adapt<List<GetReturnDetailResponse>>());
        }

        /// <summary>
        /// Получение информации о детали возврата по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var returnDetail = await _returnDetailService.GetById(id);
            if (returnDetail == null)
            {
                return NotFound();
            }
            return Ok(returnDetail.Adapt<GetReturnDetailResponse>());
        }

        /// <summary>
        /// Создание новой детали возврата
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /ReturnDetail
        ///     {
        ///         "returnID": 1,
        ///         "productID": 1,
        ///         "quantity": 2,
        ///         "unitPrice": 50.0
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateReturnDetailRequest request)
        {
            var returnDetail = request.Adapt<ReturnDetail>();
            await _returnDetailService.Create(returnDetail);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о детали возврата
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /ReturnDetail
        ///     {
        ///         "returnDetailID": 1,
        ///         "returnID": 1,
        ///         "productID": 1,
        ///         "quantity": 3,
        ///         "unitPrice": 60.0
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateReturnDetailRequest request)
        {
            var existingReturnDetail = await _returnDetailService.GetById(request.ReturnDetailID);
            if (existingReturnDetail == null)
            {
                return NotFound();
            }

            var returnDetail = request.Adapt<ReturnDetail>();
            await _returnDetailService.Update(returnDetail);
            return Ok();
        }

        /// <summary>
        /// Удаление детали возврата по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _returnDetailService.Delete(id);
            return Ok();
        }
    }
}