using AProduct.Web.Entities;
using AProduct.Web.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AProduct.Web.Data;

public class ProductRepositoryV2 : IProductRepositoryV2
{
    private readonly AppDbContext _context;

    public ProductRepositoryV2(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Product>> GetProductsPage(int pageSize, int pageNumber)
    {
        return await _context.Products
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}