using AProduct.Web.Entities;

namespace AProduct.Web.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<List<Product>> GetProductsPage(int pageSize, int pageNumber);
    Task<Product> GetProductById(int id);
    Task<Product> UpdateProduct(Product product, string description);
    Task<Product> CreateProduct(Product product);
}