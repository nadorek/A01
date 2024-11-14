using AProduct.Web.Entities;
using AProduct.Web.Interfaces;

namespace AProduct.Web.Data;

public class ProductRepository : IProductRepository
{
    public Task<List<Product>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateProduct(Product product, string description)
    {
        throw new NotImplementedException();
    }

    public Task<Product> CreateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}