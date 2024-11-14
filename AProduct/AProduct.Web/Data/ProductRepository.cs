using AProduct.Web.Entities;
using AProduct.Web.Interfaces;

namespace AProduct.Web.Data;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Product> GetProducts()
    {
        return _context.Products.AsEnumerable();
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