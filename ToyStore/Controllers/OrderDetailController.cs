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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        /// <summary>
        /// Получение информации о всех деталях заказов
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderDetails = await _orderDetailService.GetAll();
            return Ok(orderDetails.Adapt<List<GetOrderDetailResponse>>());
        }

        /// <summary>
        /// Получение информации о детали заказа по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orderDetail = await _orderDetailService.GetById(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail.Adapt<GetOrderDetailResponse>());
        }

        /// <summary>
        /// Создание новой детали заказа
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /OrderDetail
        ///     {
        ///         "orderID": 1,
        ///         "productID": 1,
        ///         "quantity": 2,
        ///         "unitPrice": 50.0
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderDetailRequest request)
        {
            var orderDetail = request.Adapt<OrderDetail>();
            await _orderDetailService.Create(orderDetail);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о детали заказа
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /OrderDetail
        ///     {
        ///         "orderDetailID": 1,
        ///         "orderID": 1,
        ///         "productID": 1,
        ///         "quantity": 3,
        ///         "unitPrice": 60.0
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDetailRequest request)
        {
            var existingOrderDetail = await _orderDetailService.GetById(request.OrderDetailID);
            if (existingOrderDetail == null)
            {
                return NotFound();
            }

            var orderDetail = request.Adapt<OrderDetail>();
            await _orderDetailService.Update(orderDetail);
            return Ok();
        }

        /// <summary>
        /// Удаление детали заказа по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderDetailService.Delete(id);
            return Ok();
        }
    }
}