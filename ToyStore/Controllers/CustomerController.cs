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
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderService _customerOrderService;

        public CustomerOrderController(ICustomerOrderService customerOrderService)
        {
            _customerOrderService = customerOrderService;
        }

        /// <summary>
        /// Получение информации о всех заказах клиентов
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _customerOrderService.GetAll();
            return Ok(orders.Adapt<List<GetCustomerOrderResponse>>());
        }

        /// <summary>
        /// Получение информации о заказе клиента по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _customerOrderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order.Adapt<GetCustomerOrderResponse>());
        }

        /// <summary>
        /// Создание нового заказа клиента
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /CustomerOrder
        ///     {
        ///         "customerID": 1,
        ///         "orderDate": "2024-01-01T00:00:00",
        ///         "totalAmount": 100.50
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateCustomerOrderRequest request)
        {
            var order = request.Adapt<CustomerOrder>();
            await _customerOrderService.Create(order);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о заказе клиента
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /CustomerOrder
        ///     {
        ///         "orderID": 1,
        ///         "customerID": 1,
        ///         "orderDate": "2024-01-01T00:00:00",
        ///         "totalAmount": 100.50
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerOrderRequest request)
        {
            var existingOrder = await _customerOrderService.GetById(request.OrderID);
            if (existingOrder == null)
            {
                return NotFound();
            }

            var order = request.Adapt<CustomerOrder>();
            await _customerOrderService.Update(order);
            return Ok();
        }

        /// <summary>
        /// Удаление заказа клиента по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerOrderService.Delete(id);
            return Ok();
        }
    }
}