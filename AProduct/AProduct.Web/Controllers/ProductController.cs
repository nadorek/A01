using AProduct.Web.Dtos;
using AProduct.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AProduct.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ProductReadDto>>> GetAllProducts()
    {
        var products = await _productRepository.GetProducts();

        if (products != null)
        {
            return Ok(products); 
        }

        return NotFound();
    }
}