using AProduct.Web.Controllers;
using AProduct.Web.Dtos;
using AProduct.Web.Entities;
using AProduct.Web.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AProduct.Tests;

public class ProductControllerTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly IMapper _mapper;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ProductReadDto>();
        });
        _mapper = mapperConfig.CreateMapper();

        _controller = new ProductController(_productRepositoryMock.Object, _mapper);
        
    }

    [Fact]
    public async Task GetAllProducts_ReturnsOkResult_WithListOfProducts()
    {
        // Arrange
        var products = new List<Product> { new Product { Id = 1, Name = "Test Product" , ImgUri = "data:image/png;base64,iVBORw0KGgoAAAANSU", Price = 20, Description = "Desc1"} };
        _productRepositoryMock.Setup(repo => repo.GetProducts()).ReturnsAsync(products);

        // Act
        var result = await _controller.GetAllProducts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<ProductReadDto>>(okResult.Value);
        Assert.Single(returnValue); 
    }

    [Fact]
    public async Task GetAllProducts_ReturnsNotFound_WhenNoProductsExist()
    {
        // Arrange
        _productRepositoryMock.Setup(repo => repo.GetProducts()).ReturnsAsync((List<Product>)null);

        // Act
        var result = await _controller.GetAllProducts();

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}