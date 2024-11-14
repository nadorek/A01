using AProduct.Web.Entities;

namespace AProduct.Web.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
    Task<Product> GetProductById(int id);
    Task<Product> UpdateProduct(Product product, string description);
    Task<Product> CreateProduct(Product product);
}