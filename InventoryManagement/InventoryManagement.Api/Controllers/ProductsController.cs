using InventoryManagement.Domain.DTOs.Product;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Api.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService service)
    {
        _productService = service;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        var result = _productService.GetProducts();

        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<ProductDto> Get(int id)
    {
        var product = _productService.GetById(id);

        if (product is null)
        {
            return NotFound($"Product with id: {id} does not exist.");
        }

        return product;
    }

    [HttpPost]
    public ActionResult<Product> Post([FromBody] ProductForCreateDto product)
    {
        var result = _productService.Create(product);

        return Created("GetById", result);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] ProductForUpdateDto product)
    {
        if (id != product.Id)
        {
            return BadRequest($"Route id: {id} does not match with product id: {product.Id}");
        }


        _productService.Update(product);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _productService.Delete(id);

        return NoContent();
    }
}
