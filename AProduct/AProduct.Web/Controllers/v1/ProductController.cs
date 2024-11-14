using AProduct.Web.Dtos;
using AProduct.Web.Entities;
using AProduct.Web.Interfaces;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AProduct.Web.Controllers;

[ApiController]
[ApiVersion("1")]
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
    
    [HttpGet]
    public async Task<ActionResult<List<ProductReadDto>>> GetAllProducts()
    {
        var products = await _productRepository.GetProducts();

        if (products != null)
        {
            var result = _mapper.Map<List<ProductReadDto>>(products);
            return Ok(result); 
        }

        return NotFound();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductReadDto>> GetProduct(int id)
    {
        var product = await _productRepository.GetProductById(id);

        if (product != null) 
        {
            var result = _mapper.Map<ProductReadDto>(product);
            return Ok(result);
        }

        return NotFound();
    }
    
    [HttpPost]
    public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<Product>(productCreateDto);
        
        var productToDto = await _productRepository.CreateProduct(product);
 
        var result = _mapper.Map<ProductReadDto>(productToDto);
        
        return CreatedAtAction(nameof(GetProduct), new { Id = result.Id }, result);
    }
    
    [HttpPatch("{id}/description")]
    public async Task<ActionResult<ProductReadDto>> UpdateProduct(int id, string description)
    {
        var product = await _productRepository.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }
        
        await _productRepository.UpdateProduct(product, description);
        
        return Ok(product);
    }
}