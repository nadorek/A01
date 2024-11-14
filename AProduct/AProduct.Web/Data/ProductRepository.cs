using AProduct.Web.Entities;
using AProduct.Web.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AProduct.Web.Data;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> UpdateProduct(Product product, string description)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        
        product.Description = description;
        
        var result = _context.Products.Update(product);  

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Product> CreateProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        
        var result = await _context.Products.AddAsync(product);
        
        await _context.SaveChangesAsync();
        
        return result.Entity;
    }
}