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
    private readonly IProductRepositoryV2 _productRepositoryV2;
    private readonly IMapper _mapper;

    public ProductController(IProductRepositoryV2 productRepositoryV2, IMapper mapper)
    {
        _productRepositoryV2 = productRepositoryV2;
        _mapper = mapper;
    }
    
    [MapToApiVersion("2")]
    [HttpGet]
    public async Task<ActionResult<List<ProductReadDto>>> GetAllProductsV2([FromQuery] int pageSize, int pageNumber)
    {
        var products = await _productRepositoryV2.GetProductsPage(pageSize, pageNumber);

        if (products != null)
        {
            var result = _mapper.Map<List<ProductReadDto>>(products);
            return Ok(result);
        }
        
        return NotFound();
    }
}