using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Mapster;
using Contracts.Requests;
using Contracts.Responses;

/// <summary>
/// Контроллер для управления продуктами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Получает список всех продуктов.
    /// </summary>
    /// <returns>Список продуктов.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetProductResponse>>> GetProducts()
    {
        var products = await _productService.GetAll();
        return Ok(products.Adapt<List<GetProductResponse>>());
    }

    /// <summary>
    /// Получает продукт по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <returns>Продукт.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetProductResponse>> GetProduct(int id)
    {
        var product = await _productService.GetById(id);
        return product == null
            ? NotFound()
            : Ok(product.Adapt<GetProductResponse>());
    }

    /// <summary>
    /// Создает новый продукт.
    /// </summary>
    /// <param name="request">Данные продукта.</param>
    /// <returns>Созданный продукт.</returns>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     POST /Products
    ///     {
    ///         "productName": "Мяч",
    ///         "categoryID": 1,
    ///         "supplierID": 1,
    ///         "price": 100,
    ///         "stockQuantity": 10
    ///     }
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult<GetProductResponse>> PostProduct(CreateProductRequest request)
    {
        var product = request.Adapt<Product>();
        await _productService.Create(product);
        return CreatedAtAction("GetProduct", new { id = product.ProductId }, product.Adapt<GetProductResponse>());
    }

    /// <summary>
    /// Обновляет данные продукта.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <param name="request">Обновленные данные продукта.</param>
    /// <returns>Статус выполнения.</returns>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     PUT /Products/{id}
    ///     {
    ///         "productId": 1,
    ///         "productName": "Мяч",
    ///         "categoryID": 1,
    ///         "supplierID": 1,
    ///         "price": 120,
    ///         "stockQuantity": 15
    ///     }
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, UpdateProductRequest request)
    {
        if (id != request.ProductID)
        {
            return BadRequest();
        }

        var product = request.Adapt<Product>();
        await _productService.Update(product);
        return NoContent();
    }

    /// <summary>
    /// Удаляет продукт по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <returns>Статус выполнения.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _productService.GetById(id);
        if (product == null)
        {
            return NotFound();
        }

        await _productService.Delete(id);
        return NoContent();
    }
}