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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Получение информации о всех транзакциях
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionService.GetAll();
            return Ok(transactions.Adapt<List<GetTransactionResponse>>());
        }

        /// <summary>
        /// Получение информации о транзакции по ID
        /// </summary>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await _transactionService.GetById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction.Adapt<GetTransactionResponse>());
        }

        /// <summary>
        /// Создание новой транзакции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Transaction
        ///     {
        ///         "transactionDate": "2024-01-01T00:00:00",
        ///         "transactionType": "Покупка",
        ///         "amount": 100.0,
        ///         "description": "Покупка игрушек"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Add(CreateTransactionRequest request)
        {
            var transaction = request.Adapt<Transaction>();
            await _transactionService.Create(transaction);
            return Ok();
        }

        /// <summary>
        /// Обновление информации о транзакции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Transaction
        ///     {
        ///         "transactionID": 1,
        ///         "transactionDate": "2024-01-01T00:00:00",
        ///         "transactionType": "Покупка",
        ///         "amount": 120.0,
        ///         "description": "Покупка игрушек"
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTransactionRequest request)
        {
            var existingTransaction = await _transactionService.GetById(request.TransactionID);
            if (existingTransaction == null)
            {
                return NotFound();
            }

            var transaction = request.Adapt<Transaction>();
            await _transactionService.Update(transaction);
            return Ok();
        }

        /// <summary>
        /// Удаление транзакции по ID
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _transactionService.Delete(id);
            return Ok();
        }
    }
}