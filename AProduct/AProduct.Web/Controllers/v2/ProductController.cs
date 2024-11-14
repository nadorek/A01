using AProduct.Web.Dtos;
using AProduct.Web.Interfaces;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AProduct.Web.Controllers.v2;

[ApiController]
[ApiVersion("2")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    [MapToApiVersion("2")]
    [HttpGet]
    public async Task<ActionResult<List<ProductReadDto>>> GetAllProductsV2([FromQuery] int pageSize, int pageNumber)
    {
        var products = await _productRepository.GetProductsPage(pageSize, pageNumber);

        if (products != null)
        {
            var result = _mapper.Map<List<ProductReadDto>>(products);
            return Ok(result);
        }
        
        return NotFound();
    }
}